﻿using System;
using System.ComponentModel.DataAnnotations;

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
    /// A single user.
    /// </summary>
    public class User
    {
        public Guid Id { get; set; }

        /// <summary>
        /// GenderType.
        /// </summary>
        public GenderType Gender { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        /// <summary>
        /// Undefined description.
        /// </summary>
        /// <remarks>
        /// Email validation being enforced.
        /// </remarks>
        [EmailAddress]
        public string? Email { get; set; }

        /// <summary>
        /// Address.
        /// </summary>
        public Address? HomeAddress { get; set; }

        /// <summary>
        /// Address.
        /// </summary>
        public Address? CompanyAddress { get; set; }

        /// <summary>
        /// Converts to string.
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Gender)}: ({Gender}), {nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}, {nameof(Email)}: {Email}, {nameof(HomeAddress)}: ({HomeAddress}), {nameof(CompanyAddress)}: ({CompanyAddress})";
        }
    }
}