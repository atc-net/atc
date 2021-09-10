using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading.Tasks;

namespace Atc.Helpers
{
    [ExcludeFromCodeCoverage]
    public static class ProcessHelper
    {
        public static Task<(bool isSuccessful, string output)> Execute(FileInfo fileInfo, string arguments)
        {
            if (fileInfo is null)
            {
                throw new ArgumentNullException(nameof(fileInfo));
            }

            if (arguments is null)
            {
                throw new ArgumentNullException(nameof(arguments));
            }

            return InvokeExecute(fileInfo, arguments);
        }

        [SuppressMessage("Major Code Smell", "S3358:Ternary operators should not be nested", Justification = "OK.")]
        private static async Task<(bool isSuccessful, string output)> InvokeExecute(FileSystemInfo fileInfo, string arguments)
        {
            using var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = fileInfo.FullName,
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                },
            };

            try
            {
                process.Start();

                var standardOutput = await process.StandardOutput.ReadToEndAsync().ConfigureAwait(false);
                var standardError = await process.StandardError.ReadToEndAsync().ConfigureAwait(false);

                var message = string.IsNullOrEmpty(standardError)
                    ? standardOutput
                    : string.IsNullOrEmpty(standardOutput)
                        ? standardError
                        : $"{standardOutput}{Environment.NewLine}{standardError}";

                return (string.IsNullOrEmpty(standardError), message);
            }
            catch (Exception ex)
            {
                return (
                    isSuccessful: false,
                    ex.GetMessage(
                        includeInnerMessage: true,
                        includeExceptionName: true));
            }
        }
    }
}