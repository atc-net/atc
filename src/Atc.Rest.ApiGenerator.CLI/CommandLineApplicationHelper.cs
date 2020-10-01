using System;
using System.IO;
using System.Linq;
using McMaster.Extensions.CommandLineUtils;

namespace Atc.Rest.ApiGenerator.CLI
{
    public static class CommandLineApplicationHelper
    {
        public static bool GetVerboseMode(CommandLineApplication configCmd)
        {
            if (configCmd == null)
            {
                throw new ArgumentNullException(nameof(configCmd));
            }

            var cmdOptionParameter = configCmd
                .GetOptions()
                .FirstOrDefault(x =>
                    x.LongName!.Equals("verboseMode", StringComparison.OrdinalIgnoreCase) ||
                    x.ShortName!.Equals("v", StringComparison.OrdinalIgnoreCase));

            if (cmdOptionParameter == null || string.IsNullOrEmpty(cmdOptionParameter.Value()))
            {
                return false;
            }

            return bool.TryParse(cmdOptionParameter.Value()!, out bool result) && result;
        }

        public static string GetSpecificationPath(CommandLineApplication configCmd)
        {
            return GetValueForParameter(configCmd, "specificationPath");
        }

        public static string GetProjectPrefixName(CommandLineApplication configCmd)
        {
            return GetValueForParameter(configCmd, "projectPrefixName", "p");
        }

        public static DirectoryInfo GetOutputPath(CommandLineApplication configCmd)
        {
            return new DirectoryInfo(GetValueForParameter(configCmd, "outputPath", "o"));
        }

        public static DirectoryInfo GetApiPath(CommandLineApplication configCmd)
        {
            return new DirectoryInfo(GetValueForParameter(configCmd, "apiPath"));
        }

        public static DirectoryInfo GetDomainPath(CommandLineApplication configCmd)
        {
            return new DirectoryInfo(GetValueForParameter(configCmd, "domainPath"));
        }

        private static string GetValueForParameter(CommandLineApplication configCmd, string parameterName, string? shortParameterName = null)
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

            if (cmdOptionParameter == null && shortParameterName != null)
            {
                cmdOptionParameter = configCmd
                    .GetOptions()
                    .FirstOrDefault(x => x.ShortName!.Equals(shortParameterName, StringComparison.OrdinalIgnoreCase));
            }

            if (cmdOptionParameter == null || string.IsNullOrEmpty(cmdOptionParameter.Value()))
            {
                throw new ArgumentNullOrDefaultException(parameterName, $"Argument {parameterName} is not specified.");
            }

            return cmdOptionParameter.Value()!;
        }
    }
}