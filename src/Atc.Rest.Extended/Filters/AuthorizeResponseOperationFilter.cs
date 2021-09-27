using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Atc.Rest.Extended.Filters
{
    public class AuthorizeResponseOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var controller = context.ApiDescription.ActionDescriptor as ControllerActionDescriptor;
            var attributes = controller?.ControllerTypeInfo.GetCustomAttributes(true);

            var controllerAuthorized = attributes?
                .OfType<AuthorizeAttribute>()
                .Any() ?? false;

            var actionAuthorized = context.MethodInfo.GetCustomAttributes(true)
                .OfType<AuthorizeAttribute>()
                .Any();

            var actionAllowAnonymous = context.MethodInfo.GetCustomAttributes(true)
                .OfType<AllowAnonymousAttribute>()
                .Any();

            if (actionAllowAnonymous || (!controllerAuthorized && !actionAuthorized))
            {
                return;
            }

            operation.Responses ??= new OpenApiResponses();
            operation.Responses["401"] = new OpenApiResponse { Description = "Request was valid but the calling user does not have the required role" };
            operation.Responses["403"] = new OpenApiResponse { Description = "The request was valid, but the server is refusing action. The user might not have the necessary permissions for a resource" };
        }
    }
}