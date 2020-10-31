using Microsoft.OpenApi.Models;

namespace Atc.OpenApi.Tests.XUnitTestData
{
    public static class TestDataOpenApiParameterOfTypeFactory
    {
        public static OpenApiParameter CreateString()
        {
            return new OpenApiParameter
            {
                Schema = TestDataOpenApiSchemaOfTypeFactory.CreateString(),
            };
        }

        public static OpenApiParameter CreateInt32()
        {
            return new OpenApiParameter
            {
                Schema = TestDataOpenApiSchemaOfTypeFactory.CreateInt32(),
            };
        }

        public static OpenApiParameter CreateInt64()
        {
            return new OpenApiParameter
            {
                Schema = TestDataOpenApiSchemaOfTypeFactory.CreateInt64(),
            };
        }

        public static OpenApiParameter CreateNumberFloat()
        {
            return new OpenApiParameter
            {
                Schema = TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat(),
            };
        }

        public static OpenApiParameter CreateStringByte()
        {
            return new OpenApiParameter
            {
                Schema = TestDataOpenApiSchemaOfTypeFactory.CreateStringByte(),
            };
        }

        public static OpenApiParameter CreateStringDate()
        {
            return new OpenApiParameter
            {
                Schema = TestDataOpenApiSchemaOfTypeFactory.CreateStringDate(),
            };
        }

        public static OpenApiParameter CreateStringDateTime()
        {
            return new OpenApiParameter
            {
                Schema = TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime(),
            };
        }

        public static OpenApiParameter CreateStringEmail()
        {
            return new OpenApiParameter
            {
                Schema = TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
            };
        }

        public static OpenApiParameter CreateStringTime()
        {
            return new OpenApiParameter
            {
                Schema = TestDataOpenApiSchemaOfTypeFactory.CreateStringTime(),
            };
        }

        public static OpenApiParameter CreateStringTimestamp()
        {
            return new OpenApiParameter
            {
                Schema = TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp(),
            };
        }

        public static OpenApiParameter CreateStringUri()
        {
            return new OpenApiParameter
            {
                Schema = TestDataOpenApiSchemaOfTypeFactory.CreateStringUri(),
            };
        }

        public static OpenApiParameter CreateStringUuid()
        {
            return new OpenApiParameter
            {
                Schema = TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid(),
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