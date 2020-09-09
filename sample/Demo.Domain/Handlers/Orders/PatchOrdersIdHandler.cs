using System;
using System.Threading;
using System.Threading.Tasks;
using Demo.Api.Generated.Contracts.Orders;

namespace Demo.Domain.Handlers.Orders
{
    public class PatchOrdersIdHandler : IPatchOrdersIdHandler
    {
        public Task<PatchOrdersIdResult> ExecuteAsync(PatchOrdersIdParameters parameters,
            CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            return parameters.Id switch
            {
                "7" => Task.FromResult(PatchOrdersIdResult.NotFound($"Could not find order with id={parameters.Id}")),
                "8" => throw new Exception("Database broken!"),
                "9" => Task.FromResult(PatchOrdersIdResult.Conflict()),
                "10" => Task.FromResult(PatchOrdersIdResult.Conflict("Something is broken - maybe a horse!")),
                "11" => Task.FromResult(PatchOrdersIdResult.BadGateway("Something is broken - maybe a horse!")),
                _ => ExecuteHelperAsync()
            };
        }

        private static async Task<PatchOrdersIdResult> ExecuteHelperAsync()
        {
            return await Task.FromResult("Data is updated");
        }
    }
}