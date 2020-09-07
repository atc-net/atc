namespace Atc.Rest.ApiGenerator.Factories
{
    internal static class ProjectScaffoldFactory
    {
        public static string[] CreateUsingListForResultFactory()
        {
            return new[]
            {
                "System.Net",
                "System.Text.Json",
                "Microsoft.AspNetCore.Mvc",
            };
        }

        public static string[] CreateUsingListForPagination()
        {
            return new[]
            {
                "System",
                "System.Collections.Generic",
            };
        }
    }
}