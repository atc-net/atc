﻿using System;
using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

//------------------------------------------------------------------------------
// This code was auto-generated by ApiGenerator 1.0.216.0.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
namespace Demo.Api.Generated.Contracts.Users
{
    /// <summary>
    /// Parameters for operation request.
    /// Description: Update user by id.
    /// Operation: UpdateUserById.
    /// Area: Users.
    /// </summary>
    [GeneratedCode("ApiGenerator", "1.0.216.0")]
    public class UpdateUserByIdParameters
    {
        /// <summary>
        /// Id of the user.
        /// </summary>
        [FromRoute(Name = "id")]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Request to update a user.
        /// </summary>
        [FromBody]
        [Required]
        public UpdateUserRequest Request { get; set; }

        /// <summary>
        /// Converts to string.
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Request)}: ({Request})";
        }
    }
}