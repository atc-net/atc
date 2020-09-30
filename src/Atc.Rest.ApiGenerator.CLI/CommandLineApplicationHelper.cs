using System;
using System.IO;
using System.Linq;
using McMaster.Extensions.CommandLineUtils;

namespace Atc.Rest.ApiGenerator.CLI
{
    public static class CommandLineApplicationHelper
    {
        public static string GetSpecificationPath(CommandLineApplication configCmd)
        {
            return GetValueForParameter(configCmd, "specificationPath");
        }

        public static string GetProjectPrefixName(CommandLineApplication configCmd)
        {
            return GetValueForParameter(configCmd, "projectPrefixName");
        }

        public static DirectoryInfo GetOutputPath(CommandLineApplication configCmd)
        {
            return new DirectoryInfo(GetValueForParameter(configCmd, "outputPath"));
        }

        public static DirectoryInfo GetApiPath(CommandLineApplication configCmd)
        {
            return new DirectoryInfo(GetValueForParameter(configCmd, "apiPath"));
        }

        public static DirectoryInfo GetDomainPath(CommandLineApplication configCmd)
        {
            return new DirectoryInfo(GetValueForParameter(configCmd, "domainPath"));
        }

        private static string GetValueForParameter(CommandLineApplication configCmd, string parameterName)
        {
            if (configCmd == null)
            {
                throw new ArgumentNullException(nameof(configCmd));
            }

            if (parameterName == null)
            {
                throw new ArgumentNullException(nameof(parameterName));
            }

            var cmdOptionParameter = configCmd
                .GetOptions()
                .FirstOrDefault(x => x.LongName!.Equals(parameterName, StringComparison.OrdinalIgnoreCase));

            if (cmdOptionParameter == null || string.IsNullOrEmpty(cmdOptionParameter.Value()))
            {
                throw new ArgumentNullOrDefaultException(parameterName, $"Argument {parameterName} is not specified.");
            }

            return cmdOptionParameter.Value()!;
        }
    }
}