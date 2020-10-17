using System.Threading;
using System.Threading.Tasks;
using Demo.Api.Generated.Contracts.Configurations;

namespace Demo.Domain.Handlers.Configurations
{
    /// <summary>
    /// Handler for operation request.
    /// Description: Get ApplicationUri by OPC UA ServerUrl.
    /// Operation: GetApplicationUriByServerUrl.
    /// Area: Configurations.
    /// </summary>
    public class GetApplicationUriByServerUrlHandler : IGetApplicationUriByServerUrlHandler
    {
        public Task<GetApplicationUriByServerUrlResult> ExecuteAsync(GetApplicationUriByServerUrlParameters parameters, CancellationToken cancellationToken = default)
        {
            if (parameters is null)
            {
                throw new System.ArgumentNullException(nameof(parameters));
            }

            return InvokeExecuteAsync(parameters, cancellationToken);
        }

        public async Task<GetApplicationUriByServerUrlResult> InvokeExecuteAsync(GetApplicationUriByServerUrlParameters parameters, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}