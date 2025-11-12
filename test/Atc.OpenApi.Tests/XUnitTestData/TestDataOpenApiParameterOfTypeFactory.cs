namespace Atc.OpenApi.Tests.XUnitTestData;

internal static class TestDataOpenApiParameterOfTypeFactory
{
    public static OpenApiParameter CreateString()
        => new()
        {
            Schema = TestDataOpenApiSchemaOfTypeFactory.CreateString(),
        };

    public static OpenApiParameter CreateInt32()
        => new()
        {
            Schema = TestDataOpenApiSchemaOfTypeFactory.CreateInt32(),
        };

    public static OpenApiParameter CreateInt64()
        => new()
        {
            Schema = TestDataOpenApiSchemaOfTypeFactory.CreateInt64(),
        };

    public static OpenApiParameter CreateNumberFloat()
        => new()
        {
            Schema = TestDataOpenApiSchemaOfTypeFactory.CreateNumberFloat(),
        };

    public static OpenApiParameter CreateStringByte()
        => new()
        {
            Schema = TestDataOpenApiSchemaOfTypeFactory.CreateStringByte(),
        };

    public static OpenApiParameter CreateStringDate()
        => new()
        {
            Schema = TestDataOpenApiSchemaOfTypeFactory.CreateStringDate(),
        };

    public static OpenApiParameter CreateStringDateTime()
        => new()
        {
            Schema = TestDataOpenApiSchemaOfTypeFactory.CreateStringDateTime(),
        };

    public static OpenApiParameter CreateStringEmail()
        => new()
        {
            Schema = TestDataOpenApiSchemaOfTypeFactory.CreateStringEmail(),
        };

    public static OpenApiParameter CreateStringTime()
        => new()
        {
            Schema = TestDataOpenApiSchemaOfTypeFactory.CreateStringTime(),
        };

    public static OpenApiParameter CreateStringTimestamp()
        => new()
        {
            Schema = TestDataOpenApiSchemaOfTypeFactory.CreateStringTimestamp(),
        };

    public static OpenApiParameter CreateStringUri()
        => new()
        {
            Schema = TestDataOpenApiSchemaOfTypeFactory.CreateStringUri(),
        };

    public static OpenApiParameter CreateStringUuid()
        => new()
        {
            Schema = TestDataOpenApiSchemaOfTypeFactory.CreateStringUuid(),
        };

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