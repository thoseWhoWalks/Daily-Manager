namespace DM.Shared.Application.Queries
{
    public interface IQueryDispatcher
    {
        TResult Query<TResult>(IQuery<TResult> query);
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
    }
}
