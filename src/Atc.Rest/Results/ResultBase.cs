using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;

namespace Atc.Rest.Results
{
    /// <summary>
    /// ResultBase.
    /// </summary>
    public abstract class ResultBase
    {
        private readonly ActionResult result;

        protected ResultBase(ActionResult result)
        {
            this.result = result ?? throw new ArgumentNullException(nameof(result));
        }

        /// <summary>
        /// Performs an implicit conversion from result to ActionResult.
        /// </summary>
        [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Ok.")]
        public static implicit operator ActionResult(ResultBase x) => x.result;
    }
}