﻿using System.ComponentModel.DataAnnotations;
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
    /// Parameters for operation request.
    /// Description: Update gender on a user.
    /// Operation: UpdateMyTestGender.
    /// Area: Users.
    /// </summary>
    public class UpdateMyTestGenderParameters
    {
        /// <summary>
        /// The id of the user to update.
        /// </summary>
        [FromRoute(Name = "id")]
        [Required]
        public string Id { get; set; }

        /// <summary>
        /// The gender to set on the user.
        /// </summary>
        [FromQuery(Name = "genderParam")]
        public GenderType? GenderParam { get; set; }

        [FromBody]
        [Required]
        public UpdateTestGenderRequest Request { get; set; }

        /// <summary>
        /// Converts to string.
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(GenderParam)}: ({GenderParam}), {nameof(Request)}: ({Request})";
        }
    }
}