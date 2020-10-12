namespace patterns.Cqs.Requests
{
    public interface IRequest<out TResponse>
    {
    }

    public interface IRequest : IRequest<Unit>
    {
    }
}