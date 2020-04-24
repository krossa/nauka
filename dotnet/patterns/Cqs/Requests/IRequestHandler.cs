using System.Threading;
using System.Threading.Tasks;
using patterns.Cqs.Result;

namespace patterns.Cqs.Requests
{
     public interface IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        Task<Result<TResponse>> HandleAsync(TRequest request, CancellationToken cancellation = default);
    }

    public interface IRequestHandler<TRequest> : IRequestHandler<TRequest, Unit> where TRequest : IRequest<Unit>
    {
    }
}