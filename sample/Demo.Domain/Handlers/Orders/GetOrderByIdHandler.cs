using System;
using System.Threading;
using System.Threading.Tasks;
using Demo.Api.Generated.Contracts;
using Demo.Api.Generated.Contracts.Orders;

namespace Demo.Domain.Handlers.Orders
{
    public class GetOrderByIdHandler : IGetOrderByIdHandler
    {
        public async Task<GetOrderByIdResult> ExecuteAsync(GetOrderByIdParameters parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            return parameters.Id switch
            {
                "7" => await Task.FromResult(GetOrderByIdResult.NotFound($"Could not find order with id={parameters.Id}")),
                "8" => throw new Exception("Crash! Boom! Bang! # " + parameters.Id),
                "9" => throw new InvalidOperationException("Crash! Boom! Bang! # " + parameters.Id),
                "10" => throw new UnauthorizedAccessException("Crash! Boom! Bang! # " + parameters.Id),
                "11" => throw new NotImplementedException("Crash! Boom! Bang! # " + parameters.Id),
                _ => await InvokeExecuteAsync(parameters, cancellationToken)
            };
        }

        private async Task<GetOrderByIdResult> InvokeExecuteAsync(GetOrderByIdParameters parameters, CancellationToken cancellationToken)
        {
            var data = new Order
            {
                Id = parameters.Id,
                Description = "MyOrder",
                DeliveryAddress = new Address
                {
                    CityName = "Glostrup",
                    PostalCode = "2600",
                    MyCountry = new Country
                    {
                        Name = "Denmark",
                        Alpha2Code = "DK",
                        Alpha3Code = "DNK"
                    }
                }
            };

            return await Task.FromResult(data);
        }
    }
}