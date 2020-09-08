﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using Microsoft.AspNetCore.Mvc;

//------------------------------------------------------------------------------
// This code was auto-generated by Atc.Rest.ApiGenerator 1.0.0.0.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
//
// ReSharper disable once CheckNamespace
namespace Demo.Api.Generated.Contracts.Users
{
    /// <summary>
    /// Results for operation request.
    /// Description: Get user by id.
    /// Operation: GetUserById.
    /// Area: Users.
    /// </summary>
    [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Should not throw ArgumentNullExceptions from implicit operators.")]
    public class GetUserByIdResult
    {
        private readonly ActionResult result;

        private GetUserByIdResult(ActionResult result)
        {
            this.result = result ?? throw new ArgumentNullException(nameof(result));
        }

        /// <summary>
        /// 200 - Ok response.
        /// </summary>
        public static GetUserByIdResult Ok(User response) => new GetUserByIdResult(new OkObjectResult(response));

        /// <summary>
        /// 404 - NotFound response.
        /// </summary>
        public static GetUserByIdResult NotFound(string? message = null) => new GetUserByIdResult(ResultFactory.CreateContentResultWithProblemDetails(HttpStatusCode.NotFound, message));

        /// <summary>
        /// 409 - Conflict response.
        /// </summary>
        public static GetUserByIdResult Conflict(string? error = null) => new GetUserByIdResult(ResultFactory.CreateContentResultWithProblemDetails(HttpStatusCode.Conflict, error));

        /// <summary>
        /// Performs an implicit conversion from GetUserByIdResult to ActionResult.
        /// </summary>
        public static implicit operator ActionResult(GetUserByIdResult x) => x.result;

        /// <summary>
        /// Performs an implicit conversion from GetUserByIdResult to ActionResult.
        /// </summary>
        public static implicit operator GetUserByIdResult(User x) => Ok(x);
    }
}