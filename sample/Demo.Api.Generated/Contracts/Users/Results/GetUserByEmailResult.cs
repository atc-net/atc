﻿using System;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using Microsoft.AspNetCore.Mvc;

//------------------------------------------------------------------------------
// This code was auto-generated by ApiGenerator 1.0.0.0.
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
    /// Description: Get user by email.
    /// Operation: GetUserByEmail.
    /// Area: Users.
    /// </summary>
    [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Should not throw ArgumentNullExceptions from implicit operators.")]
    [GeneratedCode("ApiGenerator", "1.0.0.0")]
    public class GetUserByEmailResult
    {
        private readonly ActionResult result;

        private GetUserByEmailResult(ActionResult result)
        {
            this.result = result ?? throw new ArgumentNullException(nameof(result));
        }

        /// <summary>
        /// 200 - Ok response.
        /// </summary>
        public static GetUserByEmailResult Ok(User response) => new GetUserByEmailResult(new OkObjectResult(response));

        /// <summary>
        /// 400 - BadRequest response.
        /// </summary>
        public static GetUserByEmailResult BadRequest(string message) => new GetUserByEmailResult(ResultFactory.CreateContentResultWithProblemDetails(HttpStatusCode.BadRequest, message));

        /// <summary>
        /// 404 - NotFound response.
        /// </summary>
        public static GetUserByEmailResult NotFound(string? message = null) => new GetUserByEmailResult(ResultFactory.CreateContentResultWithProblemDetails(HttpStatusCode.NotFound, message));

        /// <summary>
        /// 409 - Conflict response.
        /// </summary>
        public static GetUserByEmailResult Conflict(string? error = null) => new GetUserByEmailResult(ResultFactory.CreateContentResultWithProblemDetails(HttpStatusCode.Conflict, error));

        /// <summary>
        /// Performs an implicit conversion from GetUserByEmailResult to ActionResult.
        /// </summary>
        public static implicit operator ActionResult(GetUserByEmailResult x) => x.result;

        /// <summary>
        /// Performs an implicit conversion from GetUserByEmailResult to ActionResult.
        /// </summary>
        public static implicit operator GetUserByEmailResult(User x) => Ok(x);
    }
}