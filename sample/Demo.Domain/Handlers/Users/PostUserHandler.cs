using System;
using System.Threading;
using System.Threading.Tasks;
using Demo.Api.Generated.Contracts.Users;

namespace Demo.Domain.Handlers.Users
{
    public class PostUserHandler : IPostUserHandler
    {
        public Task<PostUserResult> ExecuteAsync(PostUserParameters parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            return InvokeExecuteAsync();
        }

        private static async Task<PostUserResult> InvokeExecuteAsync()
        {
            return await Task.FromResult(PostUserResult.Created());
        }
    }
}