﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Demo.Api.Generated.Contracts;
using Demo.Api.Generated.Contracts.Orders;
using Xunit;

//------------------------------------------------------------------------------
// This code was auto-generated by ApiGenerator 1.0.0.0.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
//--
namespace Demo.Api.Tests.Endpoints.Orders.Generated
{
    [GeneratedCode("ApiGenerator", "1.0.0.0")]
    public class PatchOrdersIdTests : WebApiControllerBaseTest
    {
        public PatchOrdersIdTests(WebApiStartupFactory fixture) : base(fixture) { }

        [Theory]
        [InlineData("/api/v1/orders/27")]
        public async Task PatchOrdersId_Ok(string relativeRef)
        {
            // Arrange
            var data = new UpdateOrderRequest
            {
                MyEmail = "john.doe@example.com",
            };

            HttpClient.DefaultRequestHeaders.Add("myTestHeader", "Hallo");

            // Act
            var response = await HttpClient.PatchAsync(relativeRef, ToJson(data));

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}