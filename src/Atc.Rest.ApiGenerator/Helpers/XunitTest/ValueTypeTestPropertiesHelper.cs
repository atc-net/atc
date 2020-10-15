using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

// ReSharper disable InvertIf
namespace Atc.Rest.ApiGenerator.Helpers.XunitTest
{
    public static class ValueTypeTestPropertiesHelper
    {
        public static string CreateValueEnum(string name, KeyValuePair<string, OpenApiSchema> schemaForEnum, bool useForBadRequest)
        {
            var enumSchema = schemaForEnum.Value.GetEnumSchema();
            var enumValues = enumSchema.Item2.Enum.ToArray();
            var openApiString = enumValues.Last() as OpenApiString;
            if (openApiString == null)
            {
                throw new NotSupportedException($"PropertyValueGeneratorEnum: {name}");
            }

            return useForBadRequest
                ? "Hallo" + openApiString.Value
                : openApiString.Value;
        }

        [SuppressMessage("Minor Code Smell", "S3400:Methods should not return constants", Justification = "OK.")]
        public static string CreateValueDouble() => "42.2";

        public static string Number(string name, bool useForBadRequest)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (useForBadRequest)
            {
                return "@";
            }

            if (name.Equals("Id", StringComparison.OrdinalIgnoreCase) || name.EndsWith("Id", StringComparison.Ordinal))
            {
                return "27";
            }

            return "42";
        }

        [SuppressMessage("Minor Code Smell", "S3400:Methods should not return constants", Justification = "OK.")]
        public static string CreateValueBool() => "true";

        public static string CreateValueString(string name, string format, bool useForBadRequest, int itemNumber = 0, string? customValue = null)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (name.Equals("Id", StringComparison.OrdinalIgnoreCase) || name.EndsWith("Id", StringComparison.Ordinal))
            {
                if (itemNumber > 0)
                {
                    return useForBadRequest
                        ? customValue ?? "27@" + itemNumber
                        : customValue ?? "27" + itemNumber;
                }

                return useForBadRequest
                    ? customValue ?? "27@"
                    : customValue ?? "27";
            }

            if (!string.IsNullOrEmpty(format) && format == OpenApiFormatTypeConstants.Email)
            {
                if (itemNumber > 0)
                {
                    return useForBadRequest
                        ? $"john{itemNumber}.doe_example.com"
                        : $"john{itemNumber}.doe@example.com";
                }

                return useForBadRequest
                    ? "john.doe_example.com"
                    : "john.doe@example.com";
            }

            return itemNumber > 0
                ? customValue ?? "Hallo" + itemNumber
                : customValue ?? "Hallo";
        }

        public static string CreateValueDateTimeOffset(bool useForBadRequest)
        {
            return useForBadRequest
                ? "x2020-10-12T21:22:23"
                : "2020-10-12T21:22:23";
        }

        [SuppressMessage("Design", "CA1055:URI-like return values should not be strings", Justification = "OK.")]
        public static string CreateValueGuid(bool useForBadRequest, int itemNumber = 0)
        {
            var numberPart = itemNumber.ToString(GlobalizationConstants.EnglishCultureInfo).PadLeft(4, '0');
            return useForBadRequest
                ? $"x77a33260-{numberPart}-441f-ba60-b0a833803fab"
                : $"77a33260-{numberPart}-441f-ba60-b0a833803fab";
        }

        [SuppressMessage("Design", "CA1055:URI-like return values should not be strings", Justification = "OK.")]
        public static string CreateValueUri(bool useForBadRequest)
        {
            return useForBadRequest
                ? "http_www_dr_dk"
                : "http://www.dr.dk";
        }
    }
}