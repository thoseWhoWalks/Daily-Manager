namespace DM.Shared.Core.Services
{
    public interface ICreateableService<TModel>
    {
        void Create(TModel model);
        Task CreateAsync(TModel model);
    }
}
