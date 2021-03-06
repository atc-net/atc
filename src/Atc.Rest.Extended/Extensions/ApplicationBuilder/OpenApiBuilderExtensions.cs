﻿using System;
using Atc.Rest.Extended.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Builder
{
    public static class OpenApiBuilderExtensions
    {
        public static IApplicationBuilder UseOpenApiSpec(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            return app.UseOpenApiSpec(env, new RestApiExtendedOptions());
        }

        public static IApplicationBuilder UseOpenApiSpec(
            this IApplicationBuilder app,
            IWebHostEnvironment env,
            RestApiExtendedOptions restApiOptions)
        {
            if (env == null)
            {
                throw new ArgumentNullException(nameof(env));
            }

            if (restApiOptions == null)
            {
                throw new ArgumentNullException(nameof(restApiOptions));
            }

            if (!restApiOptions.UseOpenApiSpec)
            {
                return app;
            }

            app.UseSwagger();
            if (env.IsDevelopment())
            {
                app.UseSwaggerUI();
            }

            return app;
        }
    }
}