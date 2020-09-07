using System;
using System.Collections.Generic;
using Atc.CodeAnalysis.CSharp.SyntaxFactories;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Atc.Rest.ApiGenerator.SyntaxFactories
{
    internal static class SyntaxEnumFactory
    {
        public static EnumDeclarationSyntax Create(string title, OpenApiSchema apiSchema)
        {
            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            if (apiSchema == null)
            {
                throw new ArgumentNullException(nameof(apiSchema));
            }

            return Create(title, apiSchema.Enum);
        }

        public static EnumDeclarationSyntax Create(string title, IList<IOpenApiAny> apiSchemaEnums)
        {
            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            if (apiSchemaEnums == null)
            {
                throw new ArgumentNullException(nameof(apiSchemaEnums));
            }

            // Create an enum
            var enumDeclaration = SyntaxFactory.EnumDeclaration(title)
                .AddModifiers(SyntaxTokenFactory.PublicKeyword());

            // Add values to the enum
            foreach (var item in apiSchemaEnums)
            {
                if (!(item is OpenApiString openApiString))
                {
                    continue;
                }

                enumDeclaration = enumDeclaration.AddMembers(SyntaxFactory.EnumMemberDeclaration(openApiString.Value));
            }

            return enumDeclaration;
        }
    }
}