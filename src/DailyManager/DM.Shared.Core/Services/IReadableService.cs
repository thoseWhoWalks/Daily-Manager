namespace DM.Shared.Core.Services
{
    public interface IReadableService<TModel>
    {
        TModel? GetById(TModel model);
        Task<TModel?> GetByIdAsync(TModel model);
    }
}
