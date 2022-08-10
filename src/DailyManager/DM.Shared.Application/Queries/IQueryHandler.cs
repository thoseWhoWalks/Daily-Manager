namespace DM.Shared.Application.Queries
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery : class, IQuery<TResult>
    {
        TResult? Handle(TQuery query);
        Task<TResult?> HandleAsync(TQuery query);
    }
}
