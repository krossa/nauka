using System.Threading;
using System.Threading.Tasks;
using patterns.Cqs.Requests;
using patterns.Cqs.Result;

namespace patterns.Cqs
{
    public interface IBus
    {
        Task<Result<TResponse>> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);

        // Task PublishAsync(INotification notification, CancellationToken cancellationToken = default);
    }
}