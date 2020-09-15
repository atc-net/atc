using System;
using System.Threading;
using System.Threading.Tasks;
using Demo.Api.Generated.Contracts.Users;

namespace Demo.Domain.Handlers.Users
{
    public class PostUsersHandler : IPostUsersHandler
    {
        public Task<PostUsersResult> ExecuteAsync(PostUsersParameters parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            return InvokeExecuteAsync();
        }

        private static async Task<PostUsersResult> InvokeExecuteAsync()
        {
            return await Task.FromResult(PostUsersResult.Created());
        }
    }
}