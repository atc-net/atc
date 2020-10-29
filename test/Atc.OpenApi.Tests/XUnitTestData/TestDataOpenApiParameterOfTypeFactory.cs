using Microsoft.OpenApi.Models;

namespace Atc.OpenApi.Tests.XUnitTestData
{
    public static class TestDataOpenApiParameterOfTypeFactory
    {
        public static OpenApiParameter CreateString()
        {
            return new OpenApiParameter
            {
                Schema = new OpenApiSchema
                {
                    Type = "string",
                },
            };
        }

        public static OpenApiParameter CreateInt32()
        {
            return new OpenApiParameter
            {
                Schema = new OpenApiSchema
                {
                    Type = "integer",
                    Format = "int32",
                },
            };
        }

        public static OpenApiParameter CreateInt64()
        {
            return new OpenApiParameter
            {
                Schema = new OpenApiSchema
                {
                    Type = "integer",
                    Format = "int64",
                },
            };
        }

        public static OpenApiParameter CreateNumberFloat()
        {
            return new OpenApiParameter
            {
                Schema = new OpenApiSchema
                {
                    Type = "number",
                    Format = "float",
                },
            };
        }

        public static OpenApiParameter CreateStringByte()
        {
            return new OpenApiParameter
            {
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Format = "byte",
                },
            };
        }

        public static OpenApiParameter CreateStringDate()
        {
            return new OpenApiParameter
            {
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Format = "date",
                },
            };
        }

        public static OpenApiParameter CreateStringDateTime()
        {
            return new OpenApiParameter
            {
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Format = "date-time",
                },
            };
        }

        public static OpenApiParameter CreateStringEmail()
        {
            return new OpenApiParameter
            {
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Format = "email",
                },
            };
        }

        public static OpenApiParameter CreateStringTime()
        {
            return new OpenApiParameter
            {
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Format = "time",
                },
            };
        }

        public static OpenApiParameter CreateStringTimestamp()
        {
            return new OpenApiParameter
            {
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Format = "timestamp",
                },
            };
        }

        public static OpenApiParameter CreateStringUri()
        {
            return new OpenApiParameter
            {
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Format = "uri",
                },
            };
        }

        public static OpenApiParameter CreateStringUuid()
        {
            return new OpenApiParameter
            {
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Format = "uuid",
                },
            };
        }

        public static OpenApiParameter CreateRouteIntId()
        {
            var parameter = CreateInt32();
            parameter.In = ParameterLocation.Path;
            parameter.Name = "id";
            return parameter;
        }

        public static OpenApiParameter CreateRouteString(string name)
        {
            var parameter = CreateString();
            parameter.In = ParameterLocation.Path;
            parameter.Name = name;
            return parameter;
        }

        public static OpenApiParameter CreateHeaderIntId()
        {
            var parameter = CreateInt32();
            parameter.In = ParameterLocation.Header;
            parameter.Name = "id";
            return parameter;
        }

        public static OpenApiParameter CreateHeaderString(string name)
        {
            var parameter = CreateString();
            parameter.In = ParameterLocation.Header;
            parameter.Name = name;
            return parameter;
        }

        public static OpenApiParameter CreateQueryIntId()
        {
            var parameter = CreateInt32();
            parameter.In = ParameterLocation.Query;
            parameter.Name = "id";
            return parameter;
        }

        public static OpenApiParameter CreateQueryString(string name)
        {
            var parameter = CreateString();
            parameter.In = ParameterLocation.Query;
            parameter.Name = name;
            return parameter;
        }
    }
}