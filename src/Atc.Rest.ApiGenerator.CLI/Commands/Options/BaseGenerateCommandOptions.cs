using System.ComponentModel.DataAnnotations;
using McMaster.Extensions.CommandLineUtils;

namespace Atc.Rest.ApiGenerator.CLI.Commands.Options
{
    public abstract class BaseGenerateCommandOptions : BaseCommandOptions
    {
        [Required]
        [Option("--projectName", "Project name.", CommandOptionType.SingleValue)]
        public string? ProjectName { get; set; }

        [Option("--outputPath", "Path to generated project.", CommandOptionType.SingleValue)]
        public string? OutputPath { get; set; }
    }
}