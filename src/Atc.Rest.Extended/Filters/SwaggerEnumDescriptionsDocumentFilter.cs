// ReSharper disable UseDeconstruction
// ReSharper disable LoopCanBeConvertedToQuery
namespace Atc.Rest.Extended.Filters;

public class SwaggerEnumDescriptionsDocumentFilter : IDocumentFilter
{
    [SuppressMessage("Minor Code Smell", "S1643:Strings should not be concatenated using '+' in a loop", Justification = "OK. For now.")]
    public void Apply(
        OpenApiDocument swaggerDoc,
        DocumentFilterContext context)
    {
        ArgumentNullException.ThrowIfNull(swaggerDoc);
        ArgumentNullException.ThrowIfNull(context);

        // Add enum descriptions to result models
        foreach (var item in swaggerDoc.Components.Schemas.Where(x => x.Value?.Enum?.Count > 0))
        {
            var propertyEnums = item.Value.Enum;
            if (propertyEnums is not null && propertyEnums.Count > 0)
            {
                item.Value.Description += DescribeEnum(propertyEnums, item.Key);
            }
        }

        // Add enum descriptions to input parameters
        foreach (var item in swaggerDoc.Paths)
        {
            DescribeEnumParameters(item.Value.Operations, swaggerDoc, context.ApiDescriptions, item.Key);
        }
    }

    [SuppressMessage("Minor Code Smell", "S1643:Strings should not be concatenated using '+' in a loop", Justification = "OK.")]
    private static void DescribeEnumParameters(
        IDictionary<OperationType, OpenApiOperation>? operations,
        OpenApiDocument document,
        IEnumerable<ApiDescription> apiDescriptions,
        string path)
    {
        if (operations is null)
        {
            return;
        }

        path = path.Trim('/');

        var pathDescriptions = apiDescriptions.Where(a => string.Equals(a.RelativePath, path, StringComparison.Ordinal)).ToList();
        foreach (var operation in operations)
        {
            var operationDescription = pathDescriptions.Find(a => a.HttpMethod!.Equals(operation.Key.ToString(), StringComparison.OrdinalIgnoreCase));
            foreach (var param in operation.Value.Parameters)
            {
                var parameterDescription = operationDescription?.ParameterDescriptions.FirstOrDefault(a => string.Equals(a.Name, param.Name, StringComparison.Ordinal));

                if (parameterDescription?.Type is null)
                {
                    continue;
                }

                if (!parameterDescription.Type.TryGetEnumType(out var enumType))
                {
                    continue;
                }

                var paramEnum = document.Components.Schemas.FirstOrDefault(x => string.Equals(x.Key, enumType.Name, StringComparison.Ordinal));
                if (paramEnum.Value is not null)
                {
                    param.Description += DescribeEnum(paramEnum.Value.Enum, paramEnum.Key);
                }
            }
        }
    }

    private static string DescribeEnum(
        IEnumerable<IOpenApiAny> enums,
        string propertyTypeName)
    {
        var enumDescriptions = new List<string>();
        var enumType = GetEnumTypeByName(propertyTypeName);
        if (enumType is null)
        {
            return null!;
        }

        foreach (var item in enums)
        {
            switch (item)
            {
                case OpenApiInteger intItem:
                {
                    var enumInt = intItem.Value;
                    enumDescriptions.Add($"{enumInt} = {Enum.GetName(enumType, enumInt)}");
                    break;
                }

                case OpenApiString stringItem:
                {
                    var enumInt = (int)Enum.Parse(enumType, stringItem.Value);
                    enumDescriptions.Add($"{enumInt} = {stringItem.Value}");
                    break;
                }
            }
        }

        return string.Join("<br />", enumDescriptions.ToArray());
    }

    private static Type? GetEnumTypeByName(string enumTypeName)
        => AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(x => x.GetTypes().Where(t => t.IsEnum))
                .Where(x => string.Equals(x.Name, enumTypeName, StringComparison.Ordinal))
                .ToArray()
            switch
            {
                { Length: 1 } a => a[0],
                _ => null,
            };
}