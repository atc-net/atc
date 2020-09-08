using System;
using System.Threading;
using System.Threading.Tasks;
using Demo.Api.Generated.Contracts.Users;

namespace Demo.Domain.Handlers.Users
{
    public class GetUserByIdHandler : IGetUserByIdHandler
    {
        public async Task<GetUserByIdResult> ExecuteAsync(GetUserByIdParameters parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            if (parameters.Id == "7")
            {
                return await Task.FromResult(GetUserByIdResult.NotFound($"Could not find user with id={parameters.Id}"));
            }

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