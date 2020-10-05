using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Demo.Api.Generated.Contracts.Users;

namespace Demo.Domain.Handlers.Users
{
    [ExcludeFromCodeCoverage]
    public class UpdateUserByIdHandler : IUpdateUserByIdHandler
    {
        public Task<UpdateUserByIdResult> ExecuteAsync(UpdateUserByIdParameters parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            return InvokeExecuteAsync(parameters, cancellationToken);
        }

        private async Task<UpdateUserByIdResult> InvokeExecuteAsync(UpdateUserByIdParameters parameters, CancellationToken cancellationToken)
        {
            return await Task.FromResult("We are now updated.");
        }
    }
}