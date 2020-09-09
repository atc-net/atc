using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Atc.CodeAnalysis.CSharp.SyntaxFactories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.OpenApi.Models;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable CheckNamespace
namespace Atc.CodeAnalysis.CSharp
{
    internal static class PropertyDeclarationSyntaxExtensions
    {
        public static PropertyDeclarationSyntax AddFromHeaderAttribute(this PropertyDeclarationSyntax propertyDeclaration, string nameProperty, OpenApiSchema schema)
        {
            if (propertyDeclaration == null)
            {
                throw new ArgumentNullException(nameof(propertyDeclaration));
            }

            if (nameProperty == null)
            {
                throw new ArgumentNullException(nameof(nameProperty));
            }

            return propertyDeclaration.AddAttributeLists(
                    SyntaxAttributeListFactory.CreateWithOneItemWithOneArgumentWithNameEquals(
                        nameof(FromHeaderAttribute),
                        nameof(FromHeaderAttribute.Name),
                        nameProperty))
                .AddValidationAttributeFromSchemaFormatIfRequired(schema);
        }

        public static PropertyDeclarationSyntax AddFromRouteAttribute(this PropertyDeclarationSyntax propertyDeclaration, string nameProperty, OpenApiSchema schema)
        {
            if (propertyDeclaration == null)
            {
                throw new ArgumentNullException(nameof(propertyDeclaration));
            }

            if (nameProperty == null)
            {
                throw new ArgumentNullException(nameof(nameProperty));
            }

            return propertyDeclaration.AddAttributeLists(
                SyntaxAttributeListFactory.CreateWithOneItemWithOneArgumentWithNameEquals(
                    nameof(FromRouteAttribute),
                    nameof(FromRouteAttribute.Name),
                    nameProperty))
                .AddValidationAttributeFromSchemaFormatIfRequired(schema);
        }

        public static PropertyDeclarationSyntax AddFromQueryAttribute(this PropertyDeclarationSyntax propertyDeclaration, string nameProperty, OpenApiSchema schema)
        {
            if (propertyDeclaration == null)
            {
                throw new ArgumentNullException(nameof(propertyDeclaration));
            }

            if (nameProperty == null)
            {
                throw new ArgumentNullException(nameof(nameProperty));
            }

            return propertyDeclaration.AddAttributeLists(
                SyntaxAttributeListFactory.CreateWithOneItemWithOneArgumentWithNameEquals(
                    nameof(FromQueryAttribute),
                    nameof(FromQueryAttribute.Name),
                    nameProperty))
                .AddValidationAttributeFromSchemaFormatIfRequired(schema);
        }

        public static PropertyDeclarationSyntax AddFromBodyAttribute(this PropertyDeclarationSyntax propertyDeclaration)
        {
            if (propertyDeclaration == null)
            {
                throw new ArgumentNullException(nameof(propertyDeclaration));
            }

            return propertyDeclaration.AddAttributeLists(SyntaxAttributeListFactory.CreateWithOneItem(nameof(FromBodyAttribute)));
        }

        public static PropertyDeclarationSyntax AddValidationAttribute(this PropertyDeclarationSyntax propertyDeclaration, ValidationAttribute validationAttribute)
        {
            if (propertyDeclaration == null)
            {
                throw new ArgumentNullException(nameof(propertyDeclaration));
            }

            if (validationAttribute == null)
            {
                throw new ArgumentNullException(nameof(validationAttribute));
            }

            return propertyDeclaration.AddAttributeLists(
                SyntaxFactory.AttributeList(
                    SyntaxFactory.SingletonSeparatedList(
                        SyntaxAttributeFactory.CreateFromValidationAttribute(validationAttribute))));
        }

        [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
        public static PropertyDeclarationSyntax AddValidationAttributeFromSchemaFormatIfRequired(this PropertyDeclarationSyntax propertyDeclaration, OpenApiSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            if (!string.IsNullOrEmpty(schema.Format))
            {
                return schema.Format.ToLower(CultureInfo.CurrentCulture) switch
                {
                    OpenApiFormatTypeConstants.Uuid => propertyDeclaration,

                    OpenApiFormatTypeConstants.Date => propertyDeclaration,
                    OpenApiFormatTypeConstants.Time => propertyDeclaration,
                    OpenApiFormatTypeConstants.Timestamp => propertyDeclaration,
                    OpenApiFormatTypeConstants.DateTime => propertyDeclaration,

                    OpenApiFormatTypeConstants.Byte => propertyDeclaration,
                    OpenApiFormatTypeConstants.Int32 => propertyDeclaration,
                    OpenApiFormatTypeConstants.Int64 => propertyDeclaration,

                    OpenApiFormatTypeConstants.Email => propertyDeclaration.AddValidationAttributeEmail(schema),
                    OpenApiFormatTypeConstants.Uri => propertyDeclaration.AddValidationAttribute(new UrlAttribute()),

                    _ => throw new NotImplementedException($"Schema Format '{schema.Format}' must be implemented.")
                };
            }

            return propertyDeclaration;
        }

        public static PropertyDeclarationSyntax AddValidationAttributeEmail(this PropertyDeclarationSyntax propertyDeclaration, OpenApiSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            propertyDeclaration = propertyDeclaration.AddValidationAttribute(new EmailAddressAttribute());
            if (!string.IsNullOrEmpty(schema.Pattern))
            {
                propertyDeclaration = propertyDeclaration.AddValidationAttribute(new RegularExpressionAttribute(schema.Pattern));
            }

            return propertyDeclaration;
        }

        public static PropertyDeclarationSyntax AddValidationAttributeForMinMaxIfRequired(this PropertyDeclarationSyntax propertyDeclaration, OpenApiSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            if (schema.Type == OpenApiDataTypeConstants.String &&
                schema.MinLength == null &&
                schema.MaxLength != null)
            {
                propertyDeclaration = propertyDeclaration.AddValidationAttribute(new StringLengthAttribute(schema.MaxLength.Value));
            }
            else
            {
                if (schema.MinLength != null && schema.MinLength.Value > 0)
                {
                    propertyDeclaration = propertyDeclaration.AddValidationAttribute(new MinLengthAttribute(schema.MinLength.Value));
                }

                if (schema.MaxLength != null && schema.MaxLength.Value > 0)
                {
                    propertyDeclaration = propertyDeclaration.AddValidationAttribute(new MaxLengthAttribute(schema.MaxLength.Value));
                }

                if (schema.Minimum != null || schema.Maximum != null)
                {
                    var min = schema.Minimum ?? 0;
                    var max = schema.Maximum ?? 0;
                    if (max < min)
                    {
                        max = min;
                    }

                    var chars = new[] { ',', '.' };
                    if (min.ToString(CultureInfo.CurrentCulture).IndexOfAny(chars) != -1 ||
                        max.ToString(CultureInfo.CurrentCulture).IndexOfAny(chars) != -1)
                    {
                        propertyDeclaration = propertyDeclaration.AddValidationAttribute(new RangeAttribute((double)min, (double)max));
                    }
                    else
                    {
                        propertyDeclaration = propertyDeclaration.AddValidationAttribute(new RangeAttribute((int)min, (int)max));
                    }
                }
            }

            return propertyDeclaration;
        }
    }
}