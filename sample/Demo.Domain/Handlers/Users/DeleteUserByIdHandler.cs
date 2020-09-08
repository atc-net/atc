using System;
using System.Threading;
using System.Threading.Tasks;
using Demo.Api.Generated.Contracts.Users;

namespace Demo.Domain.Handlers.Users
{
    public class DeleteUserByIdHandler : IDeleteUserByIdHandler
    {
        public async Task<DeleteUserByIdResult> ExecuteAsync(DeleteUserByIdParameters parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            if (parameters.Id == "7")
            {
                return await Task.FromResult(DeleteUserByIdResult.NotFound($"Can't find user with id={parameters.Id}"));
            }

            return await Task.FromResult("User deleted.");
        }
    }
}