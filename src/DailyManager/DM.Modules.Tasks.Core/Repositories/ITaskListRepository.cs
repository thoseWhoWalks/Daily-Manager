using DM.Modules.Tasks.Core.Aggregates;
using DM.Shared.Core.Repositories;

namespace DM.Modules.Tasks.Core.Repositories
{
    public interface ITaskListRepository :
        ICreateable<TaskList>,
        IUpdateable<TaskList>,
        ISearchable<TaskList>,
        IFetchable<TaskList>
    {
    }
}
