using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Atc.CodeAnalysis.CSharp;
using Atc.CodeAnalysis.CSharp.SyntaxFactories;
using Atc.Rest.ApiGenerator.Models;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Atc.Rest.ApiGenerator.SyntaxFactories
{
    internal static class SyntaxPropertyDeclarationFactory
    {
        public static PropertyDeclarationSyntax CreateAuto(
            SchemaMapLocatedAreaType locationArea,
            bool isRequired,
            bool isEnum,
            string dataType,
            string propertyName,
            bool useNullableReferenceTypes,
            IOpenApiAny? initializer)
        {
            if (useNullableReferenceTypes && DetermineIfNullableReferenceTypeCanBeOmittedOnProperty(locationArea, isRequired, isEnum, dataType))
            {
                useNullableReferenceTypes = false;
            }

            if (useNullableReferenceTypes)
            {
                dataType += "?";
            }

            var propertyDeclaration = CreateAuto(dataType, propertyName);

            if (initializer != null)
            {
                propertyDeclaration = initializer switch
                {
                    OpenApiInteger apiInteger => propertyDeclaration.WithInitializer(
                            SyntaxFactory.EqualsValueClause(SyntaxFactory.LiteralExpression(
                                SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(apiInteger!.Value))))
                        .WithSemicolonToken(SyntaxTokenFactory.Semicolon()),
                    OpenApiString apiString => propertyDeclaration.WithInitializer(
                            SyntaxFactory.EqualsValueClause(SyntaxFactory.LiteralExpression(
                                SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal(apiString!.Value))))
                        .WithSemicolonToken(SyntaxTokenFactory.Semicolon()),
                    _ => throw new NotImplementedException("Property initializer: " + initializer.GetType())
                };
            }

            return propertyDeclaration;
        }

        public static PropertyDeclarationSyntax CreateAuto(
            SchemaMapLocatedAreaType locationArea,
            KeyValuePair<string, OpenApiSchema> schema,
            ISet<string> requiredProperties,
            bool useNullableReferenceTypes)
        {
            if (requiredProperties == null)
            {
                throw new ArgumentNullException(nameof(requiredProperties));
            }

            var isRequired = requiredProperties.Contains(schema.Key);

            var propertyDeclaration = schema.Value.Type == OpenApiDataTypeConstants.Array
                ? CreateListAuto(
                    schema.Value.Items.GetDataType(),
                    schema.Key.EnsureFirstCharacterToUpper())
                : CreateAuto(
                    locationArea,
                    isRequired,
                    schema.Value.IsSchemaEnumOrPropertyEnum(),
                    schema.Value.GetDataType(),
                    schema.Key.EnsureFirstCharacterToUpper(),
                    useNullableReferenceTypes,
                    schema.Value.Default);

            if (isRequired)
            {
                propertyDeclaration = propertyDeclaration.AddValidationAttribute(new RequiredAttribute());
            }

            propertyDeclaration = propertyDeclaration.AddValidationAttributeFromSchemaFormatIfRequired(schema.Value);

            propertyDeclaration = propertyDeclaration.AddValidationAttributeForMinMaxIfRequired(schema.Value);

            return propertyDeclaration;
        }

        public static PropertyDeclarationSyntax CreateAuto(OpenApiParameter parameter, bool useNullableReferenceTypes)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }

            if (parameter.In == ParameterLocation.Path)
            {
                useNullableReferenceTypes = false;
            }
            else if (parameter.Schema.Default != null &&
                     (parameter.In == ParameterLocation.Query ||
                      parameter.In == ParameterLocation.Header))
            {
                useNullableReferenceTypes = false;
            }

            var propertyDeclaration = CreateAuto(
                SchemaMapLocatedAreaType.Parameter,
                parameter.Required,
                parameter.Schema.IsSchemaEnumOrPropertyEnum(),
                parameter.Schema.GetDataType(),
                parameter.Name.EnsureFirstCharacterToUpper(),
                useNullableReferenceTypes,
                parameter.Schema.Default);

            propertyDeclaration = parameter.In switch
            {
                ParameterLocation.Header => propertyDeclaration.AddFromHeaderAttribute(parameter.Name, parameter.Schema),
                ParameterLocation.Path => propertyDeclaration.AddFromRouteAttribute(parameter.Name, parameter.Schema),
                ParameterLocation.Query => propertyDeclaration.AddFromQueryAttribute(parameter.Name, parameter.Schema),
                _ => throw new NotImplementedException("ParameterLocation: " + nameof(ParameterLocation) + " " + parameter.In)
            };

            if (parameter.Required)
            {
                propertyDeclaration = propertyDeclaration.AddValidationAttribute(new RequiredAttribute());
            }

            return propertyDeclaration;
        }

        public static PropertyDeclarationSyntax CreateAuto(string dataType, string propertyName)
        {
            var propertyDeclaration = SyntaxFactory
                .PropertyDeclaration(SyntaxFactory.ParseTypeName(dataType), propertyName)
                .AddModifiers(SyntaxTokenFactory.PublicKeyword())
                .AddAccessorListAccessors(
                    SyntaxAccessorDeclarationFactory.Get(),
                    SyntaxAccessorDeclarationFactory.Set());

            return propertyDeclaration;
        }

        public static PropertyDeclarationSyntax CreateListAuto(string dataType, string propertyName, bool initializeList = true)
        {
            var propertyDeclaration = SyntaxFactory.PropertyDeclaration(
                    SyntaxFactory.GenericName(SyntaxFactory.Identifier("List"))
                        .WithTypeArgumentList(SyntaxTypeArgumentListFactory.CreateWithOneItem(dataType)),
                    SyntaxFactory.Identifier(propertyName))
                .AddModifiers(SyntaxTokenFactory.PublicKeyword())
                .WithAccessorList(
                    SyntaxFactory.AccessorList(
                        SyntaxFactory.List(
                            new[]
                            {
                                SyntaxAccessorDeclarationFactory.Get(),
                                SyntaxAccessorDeclarationFactory.Set()
                            })));

            if (initializeList)
            {
                propertyDeclaration = propertyDeclaration.WithInitializer(
                        SyntaxFactory.EqualsValueClause(
                            SyntaxFactory.ObjectCreationExpression(
                                    SyntaxFactory.GenericName(SyntaxFactory.Identifier("List"))
                                        .WithTypeArgumentList(SyntaxTypeArgumentListFactory.CreateWithOneItem(dataType)))
                                .WithArgumentList(SyntaxFactory.ArgumentList())))
                    .WithSemicolonToken(SyntaxTokenFactory.Semicolon());
            }

            return propertyDeclaration;
        }

        private static bool DetermineIfNullableReferenceTypeCanBeOmittedOnProperty(
            SchemaMapLocatedAreaType locationArea,
            bool isRequired,
            bool isEnum,
            string dataType)
        {
            if (isRequired && locationArea == SchemaMapLocatedAreaType.Response && dataType == "string")
            {
                return true;
            }

            if (!isRequired && locationArea != SchemaMapLocatedAreaType.RequestBody && dataType == "string")
            {
                return false;
            }

            return locationArea switch
            {
                SchemaMapLocatedAreaType.Response => IsSimpleDotNetType(dataType) || isEnum,
                SchemaMapLocatedAreaType.Parameter => isRequired && !isEnum,
                SchemaMapLocatedAreaType.RequestBody => isRequired,
                _ => throw new ArgumentOutOfRangeException(nameof(locationArea), locationArea, null)
            };
        }

        private static bool IsSimpleDotNetType(string dataType)
        {
            if (dataType == "bool" ||
                dataType == "DateTimeOffset" ||
                dataType == "double" ||
                dataType == "Guid" ||
                dataType == "int" ||
                dataType == "long" ||
                dataType == "string" ||
                dataType == "Uri")
            {
                return true;
            }

            return false;
        }
    }
}