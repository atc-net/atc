using Demo.Api.Generated.Contracts.Orders;
using Demo.Api.Generated.Contracts.Users;
using Demo.Domain.Handlers.Orders;
using Demo.Domain.Handlers.Users;
using Demo.Domain.Validators.Users;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Api.Full.Configuration
{
    public static class Configure
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            // Handlers
            services.AddTransient<IGetOrderByIdHandler, GetOrderByIdHandler>();
            services.AddTransient<IGetUserByIdHandler, GetUserByIdHandler>();
            services.AddTransient<IGetUserByEmailHandler, GetUserByEmailHandler>();

            // Validators
            services.AddTransient<IValidator<PostUsersParameters>, PostUsersParametersValidator>();
        }
    }
}