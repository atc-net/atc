using System;
using System.Threading;
using System.Threading.Tasks;
using Demo.Api.Generated.Contracts.Orders;

namespace Demo.Domain.Handlers.Orders
{
    public class PatchOrdersIdHandler : IPatchOrdersIdHandler
    {
        public async Task<PatchOrdersIdResult> ExecuteAsync(PatchOrdersIdParameters parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            if (parameters.Id == "7")
            {
                return await Task.FromResult(PatchOrdersIdResult.NotFound($"Could not find order with id={parameters.Id}"));
            }

            if (parameters.Id == "8")
            {
                throw new Exception("Database broken!");
            }

            if (parameters.Id == "9")
            {
                return await Task.FromResult(PatchOrdersIdResult.Conflict());
            }

            if (parameters.Id == "10")
            {
                return await Task.FromResult(PatchOrdersIdResult.Conflict("Something is broken - maybe a horse!"));
            }

            if (parameters.Id == "11")
            {
                return await Task.FromResult(PatchOrdersIdResult.BadGateway("Something is broken - maybe a horse!"));
            }

            return await Task.FromResult("Data is updated");
        }
    }
}