using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Atc.Rest.Options
{
    public class AllowAnonymousAccessForDevelopmentHandler : IAuthorizationHandler
    {
        private readonly IWebHostEnvironment environment;
        private readonly RestApiOptions apiOptions;

        public AllowAnonymousAccessForDevelopmentHandler(
            IWebHostEnvironment environment,
            RestApiOptions apiOptions)
        {
            this.environment = environment ?? throw new ArgumentNullException(nameof(environment));
            this.apiOptions = apiOptions ?? throw new ArgumentNullException(nameof(apiOptions));
        }

        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (!apiOptions.AllowAnonymousAccessForDevelopment && !environment.IsDevelopment())
            {
                return Task.CompletedTask;
            }

            foreach (var requirement in context.PendingRequirements.ToList())
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}