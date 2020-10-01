using System.ComponentModel.DataAnnotations;
using McMaster.Extensions.CommandLineUtils;

namespace Atc.Rest.ApiGenerator.CLI.Commands.Options
{
    public class ServerDomainCommandOptions : BaseGenerateCommandOptions
    {
        [Required]
        [Option("--apiPath", "Path to api project.", CommandOptionType.SingleValue)]
        public string? ApiPath { get; set; }
    }
}