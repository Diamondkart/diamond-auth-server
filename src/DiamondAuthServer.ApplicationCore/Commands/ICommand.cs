using MediatR;

namespace DiamondAuthServer.ApplicationCore.Commands
{
    public interface ICommand : IRequest
    {
    }

    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}