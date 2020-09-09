using System;
using System.Threading;
using System.Threading.Tasks;
using Demo.Api.Generated.Contracts.Users;

// ReSharper disable ConvertIfStatementToReturnStatement
namespace Demo.Domain.Handlers.Users
{
    public class GetUserByIdHandler : IGetUserByIdHandler
    {
        public Task<GetUserByIdResult> ExecuteAsync(GetUserByIdParameters parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            if (parameters.Id == "7")
            {
                return Task.FromResult(GetUserByIdResult.NotFound($"Could not find user with id={parameters.Id}"));
            }

            return ExecuteHelperAsync();
        }

        private static async Task<GetUserByIdResult> ExecuteHelperAsync()
        {
            var data = new User
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "John.Doe@jd.com"
            };

            return await Task.FromResult(data);
        }
    }
}