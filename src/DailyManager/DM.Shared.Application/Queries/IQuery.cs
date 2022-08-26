using MediatR;

namespace DM.Shared.Application.Queries
{
    public interface IQuery<TResult> : IRequest<TResult>
    {
    }
}