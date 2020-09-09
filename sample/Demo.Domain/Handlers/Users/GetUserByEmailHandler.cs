using System;
using System.Threading;
using System.Threading.Tasks;
using Demo.Api.Generated.Contracts.Users;

// ReSharper disable ConvertIfStatementToReturnStatement
namespace Demo.Domain.Handlers.Users
{
    public class GetUserByEmailHandler : IGetUserByEmailHandler
    {
        public Task<GetUserByEmailResult> ExecuteAsync(GetUserByEmailParameters parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            if (parameters.Email == "a@a.com")
            {
                return Task.FromResult(GetUserByEmailResult.NotFound($"Could not find user with email={parameters.Email}"));
            }

            return ExecuteHelperAsync(parameters);
        }

        private static async Task<GetUserByEmailResult> ExecuteHelperAsync(GetUserByEmailParameters parameters)
        {
            var data = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Email = parameters.Email
            };

            return await Task.FromResult(data);
        }
    }
}