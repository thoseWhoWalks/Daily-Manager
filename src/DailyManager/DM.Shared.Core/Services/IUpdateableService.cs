namespace DM.Shared.Core.Services
{
    public interface IUpdateableService<TModel>
    {
        void Update(TModel model);
        Task UpdateAsync(TModel model);
    }
}
