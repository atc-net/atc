// ReSharper disable InvertIf
namespace Atc.XUnit.Internal.AbstractSyntaxTree;

internal static class DecompilerHelper
{
    private static readonly ConcurrentDictionary<string, Lazy<CSharpDecompiler>> Cache = new(StringComparer.OrdinalIgnoreCase);

    internal static CSharpDecompiler GetDecompiler(Assembly assembly)
    {
        var assemblyFileName = assembly.Location;
        return Cache.GetOrAdd(assemblyFileName, static path =>
            new Lazy<CSharpDecompiler>(() => CreateDecompiler(path), LazyThreadSafetyMode.ExecutionAndPublication)).Value;
    }

    private static CSharpDecompiler CreateDecompiler(string assemblyFileName)
    {
        // PEFile is used only to validate the assembly path; the resolver is the long-lived handle.
        // Close the validation PEFile immediately to avoid keeping the native handle open.
        using var module = new PEFile(assemblyFileName);
        var resolver = new UniversalAssemblyResolver(assemblyFileName, false, targetFramework: null);
        return new CSharpDecompiler(assemblyFileName, resolver, GetSettings());
    }

    internal static DecompilerSettings GetSettings()
        => new()
        {
            ThrowOnAssemblyResolveErrors = false,
        };

    internal static Tuple<MethodInfo, MethodDeclaration>[] GetTestMethodsWithDecompiled(
        CSharpDecompiler decompiler,
        Tuple<Type, MethodInfo[]>[] testTypeMethods)
    {
        var testMethods = new List<Tuple<MethodInfo, MethodDeclaration>>();
        foreach (var (testType, testMethodInfos) in testTypeMethods)
        {
            if (testType.FullName is null)
            {
                continue;
            }

            var fullTypeName = new FullTypeName(testType.FullName);
            var syntaxTree = decompiler.DecompileType(fullTypeName);
            var astNodes = syntaxTree
                .Descendants
                .OfType<MethodDeclaration>()
                .ToArray();

            foreach (var testMethodInfo in testMethodInfos)
            {
                testMethods.AddRange(
                    astNodes
                        .Where(methodDeclaration => methodDeclaration.Name.Equals(testMethodInfo.Name, StringComparison.Ordinal))
                        .Select(methodDeclaration => new Tuple<MethodInfo, MethodDeclaration>(testMethodInfo, methodDeclaration)));
            }
        }

        return [.. testMethods];
    }
}