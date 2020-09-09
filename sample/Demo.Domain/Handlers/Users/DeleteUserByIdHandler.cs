using System;
using System.Threading;
using System.Threading.Tasks;
using Demo.Api.Generated.Contracts.Users;

// ReSharper disable ConvertIfStatementToReturnStatement
namespace Demo.Domain.Handlers.Users
{
    public class DeleteUserByIdHandler : IDeleteUserByIdHandler
    {
        public Task<DeleteUserByIdResult> ExecuteAsync(DeleteUserByIdParameters parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            if (parameters.Id == "7")
            {
                return Task.FromResult(DeleteUserByIdResult.NotFound($"Can't find user with id={parameters.Id}"));
            }

            return ExecuteHelperAsync();
        }

        private static async Task<DeleteUserByIdResult> ExecuteHelperAsync()
        {
            return await Task.FromResult("User deleted.");
        }
    }
}