using MediatR;

namespace DM.Shared.Application.Queries
{
    public interface IQueryHandler<in TQuery, TResult> 
        : IRequestHandler<TQuery, TResult>
        where TQuery : class, IQuery<TResult> 
    {
        TResult? Handle(TQuery query);
        Task<TResult?> HandleAsync(TQuery query);
        // Note: Till in-memory dispatcher used, can be moved to base class...etc.
        async Task<TResult> IRequestHandler<TQuery, TResult>.Handle(TQuery query, CancellationToken cancellationToken)
            => await HandleAsync(query);
    }
}
