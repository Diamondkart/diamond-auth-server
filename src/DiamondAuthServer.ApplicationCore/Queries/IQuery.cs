using MediatR;

namespace DiamondAuthServer.ApplicationCore.Queries
{
    public interface IQuery : IRequest
    {
    }

    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}