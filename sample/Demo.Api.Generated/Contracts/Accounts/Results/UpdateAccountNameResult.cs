﻿using System;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using Microsoft.AspNetCore.Mvc;

//------------------------------------------------------------------------------
// This code was auto-generated by ApiGenerator 1.0.147.0.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
//
// ReSharper disable once CheckNamespace
namespace Demo.Api.Generated.Contracts.Accounts
{
    /// <summary>
    /// Results for operation request.
    /// Description: Update name of account.
    /// Operation: UpdateAccountName.
    /// Area: Accounts.
    /// </summary>
    [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Should not throw ArgumentNullExceptions from implicit operators.")]
    [GeneratedCode("ApiGenerator", "1.0.147.0")]
    public class UpdateAccountNameResult
    {
        private readonly ActionResult result;

        private UpdateAccountNameResult(ActionResult result)
        {
            this.result = result ?? throw new ArgumentNullException(nameof(result));
        }

        /// <summary>
        /// 200 - Ok response.
        /// </summary>
        public static UpdateAccountNameResult Ok(string? message = null) => new UpdateAccountNameResult(ResultFactory.CreateContentResult(HttpStatusCode.OK, message));

        /// <summary>
        /// Performs an implicit conversion from UpdateAccountNameResult to ActionResult.
        /// </summary>
        public static implicit operator ActionResult(UpdateAccountNameResult x) => x.result;

        /// <summary>
        /// Performs an implicit conversion from UpdateAccountNameResult to ActionResult.
        /// </summary>
        public static implicit operator UpdateAccountNameResult(string x) => Ok(x);
    }
}