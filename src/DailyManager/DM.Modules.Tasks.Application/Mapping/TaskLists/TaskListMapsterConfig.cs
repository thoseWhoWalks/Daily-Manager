using DM.Modules.Tasks.Core.Aggregates;
using DM.Modules.Tasks.Shared.Models.TaskLists;
using DM.Shared.Application.Mapping;
using Mapster;

namespace DM.Modules.Tasks.Application.Mapping.TaskLists
{
    internal class TaskListMapsterConfig : IMapperConfig
    {
        public void Create()
        {
            CreateTaskListMap();
        }

        #region Private methods

        private void CreateTaskListMap()
        {
            TypeAdapterConfig<TaskList, TaskListModel>
                .NewConfig()
                .Map(dest => dest.Title,
                     model => model.Title)
                .Map(dest => dest.Description,
                     model => model.Description)
                .Map(dest => dest.IsDeleted,
                     model => model.IsDeleted)
                .Map(dest => dest.CreatedAt,
                     model => model.CreatedAt)
                .Map(dest => dest.DeletedAt,
                     model => model.DeletedAt);

            TypeAdapterConfig<TaskList, TaskListListItemModel>
                .NewConfig()
                .Map(dest => dest.Title,
                     model => model.Title)
                .Map(dest => dest.OpenedTaskCount,
                     model => model.OpenedTaskCount);
        }

        #endregion
    }
}
