using System.Threading;
using System.Threading.Tasks;
using Demo.Api.Generated.Contracts.Addresses;

namespace Demo.Domain.Handlers.Addresses
{
    /// <summary>
    /// Handler for operation request.
    /// Description: Get addresses by postal code.
    /// Operation: GetAddressesByPostalCodes.
    /// Area: Addresses.
    /// </summary>
    public class GetAddressesByPostalCodesHandler : IGetAddressesByPostalCodesHandler
    {
        public Task<GetAddressesByPostalCodesResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}