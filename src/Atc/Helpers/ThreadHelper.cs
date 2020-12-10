using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Atc.Helpers
{
    /// <summary>
    /// ThreadHelper.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ThreadHelper
    {
        /// <summary>
        /// Gets the parallel options.
        /// </summary>
        /// <param name="exemptProcessorCount">The exempt processor count.</param>
        public static ParallelOptions GetParallelOptions(int exemptProcessorCount = 2)
        {
            if (exemptProcessorCount > 0 && Environment.ProcessorCount > exemptProcessorCount)
            {
                return new ParallelOptions
                {
                    MaxDegreeOfParallelism = Environment.ProcessorCount - exemptProcessorCount,
                };
            }

            return new ParallelOptions();
        }
    }
}