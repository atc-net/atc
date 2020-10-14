﻿using System.CodeDom.Compiler;
using System.Threading;
using System.Threading.Tasks;

//------------------------------------------------------------------------------
// This code was auto-generated by ApiGenerator 1.0.0.0.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
//
// ReSharper disable once CheckNamespace
namespace Demo.Api.Generated.Contracts.Orders
{
    /// <summary>
    /// Domain Interface for RequestHandler.
    /// Description: Update part of order by id.
    /// Operation: PatchOrdersId.
    /// Area: Orders.
    /// </summary>
    [GeneratedCode("ApiGenerator", "1.0.0.0")]
    public interface IPatchOrdersIdHandler
    {
        /// <summary>
        /// Execute method.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<PatchOrdersIdResult> ExecuteAsync(PatchOrdersIdParameters parameters, CancellationToken cancellationToken = default);
    }
}