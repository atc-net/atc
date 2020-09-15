using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Demo.Api.Generated;
using Demo.Api.Generated.Contracts.Orders;

namespace Demo.Domain.Handlers.Orders
{
    public class GetOrdersHandler : IGetOrdersHandler
    {
        public Task<GetOrdersResult> ExecuteAsync(GetOrdersParameters parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            return InvokeExecuteAsync(parameters);
        }

        private static async Task<GetOrdersResult> InvokeExecuteAsync(GetOrdersParameters parameters)
        {

            var allItems = new List<Order>();
            for (var i = 0; i < 347; i++)
            {
                allItems.Add(
                    new Order
                    {
                        Id = (i + 1).ToString(CultureInfo.CurrentCulture),
                        Description = $"Test order {i + 1}"
                    });
            }

            var items = allItems
                .Skip(parameters.PageIndex)
                .Take(parameters.PageSize)
                .ToList();

            Pagination<Order> data;
            if (string.IsNullOrEmpty(parameters.ContinuationToken))
            {
                data = new Pagination<Order>(
                    items,
                    parameters.PageSize,
                    parameters.QueryString,
                    parameters.PageIndex,
                    allItems.Count);
            }
            else
            {
                data = new Pagination<Order>(
                    items,
                    parameters.PageSize,
                    parameters.QueryString,
                    parameters.ContinuationToken);
            }

            return await Task.FromResult(data);
        }
    }
}