using DM.Shared.Application.Queries;
using MediatR;

namespace DM.Shared.Infrastructure.Queries
{
    internal class QueryDispatcher : IQueryDispatcher
    {
        #region Dependencies

        private readonly IMediator _mediator;

        #endregion

        public QueryDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public TResult? Query<TResult>(IQuery<TResult> query)
        {
            return (TResult?)_mediator.Send(query).GetAwaiter().GetResult();
        }

        public async Task<TResult?> QueryAsync<TResult>(IQuery<TResult> query, 
            CancellationToken cancellationToken = default)
        {
            return (TResult?) await _mediator.Send(query, cancellationToken);
        }
    }
}
