using System;
using System.Threading;
using System.Threading.Tasks;
using Demo.Api.Generated.Contracts.Users;

namespace Demo.Domain.Handlers.Users
{
    public class UpdateUserByIdHandler : IUpdateUserByIdHandler
    {
        public Task<UpdateUserByIdResult> ExecuteAsync(UpdateUserByIdParameters parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            return InvokeExecuteAsync();
        }

        private static async Task<UpdateUserByIdResult> InvokeExecuteAsync()
        {
            return await Task.FromResult("We are now updated.");
        }
    }
}