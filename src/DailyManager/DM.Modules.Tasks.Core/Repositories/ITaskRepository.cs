using DM.Shared.Core.Repositories;
using Task = DM.Modules.Tasks.Core.Aggregates.Task;

namespace DM.Modules.Tasks.Core.Repositories
{
    public interface ITaskRepository :
        ICreateable<Task>,
        IUpdateable<Task>,
        ISearchable<Task>,
        IFetchable<Task>
    {
    }
}
