using System;
using System.IO;
using Atc.Data.Models;
using Atc.Rest.ApiGenerator.Models;

namespace Atc.Rest.ApiGenerator.Helpers
{
    public static class GenerateServerHostHelper
    {
        public static LogKeyValueItem ValidateVersioning(HostProjectOptions hostProjectOptions)
        {
            if (hostProjectOptions == null)
            {
                throw new ArgumentNullException(nameof(hostProjectOptions));
            }

            var apiFile = new FileInfo(Path.Combine(hostProjectOptions.ApiProjectSrcPath.FullName, "ApiGenerated.cs"));
            if (!File.Exists(apiFile.FullName))
            {
                return LogItemHelper.Create(LogCategoryType.Error, ValidationRuleNameConstants.ProjectHostGenerated02, $"Can't find API project in folder '{hostProjectOptions.ApiProjectSrcPath.FullName}'");
            }

            var domainFile = new FileInfo(Path.Combine(hostProjectOptions.DomainProjectSrcPath.FullName, "DomainRegistration.cs"));
            if (!File.Exists(domainFile.FullName))
            {
                return LogItemHelper.Create(LogCategoryType.Error, ValidationRuleNameConstants.ProjectHostGenerated03, $"Can't find domain project in folder '{hostProjectOptions.DomainProjectSrcPath.FullName}'");
            }

            if (!Directory.Exists(hostProjectOptions.PathForSrcGenerate.FullName))
            {
                return LogItemHelper.Create(LogCategoryType.Information, ValidationRuleNameConstants.ProjectHostGenerated01, "Old project don't exist.");
            }

            return LogItemHelper.Create(LogCategoryType.Warning, "#", "Imp. Server-Domain ValidateVersioning.");
        }
    }
}