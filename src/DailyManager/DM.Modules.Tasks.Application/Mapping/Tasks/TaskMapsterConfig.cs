using DM.Modules.Tasks.Shared.Models.Tasks;
using DM.Shared.Application.Mapping;
using Mapster;
using Task = DM.Modules.Tasks.Core.Aggregates.Task;

namespace DM.Modules.Tasks.Application.Mapping.Tasks
{
    internal class TaskMapsterConfig : IMapperConfig
    {
        public void Create()
        {
            CreateTaskMap();
        }

        #region Private methods

        private void CreateTaskMap()
        {
            TypeAdapterConfig<Task, TaskModel>
                .NewConfig()
                .Map(dest => dest.Title,
                     model => model.Title)
                .Map(dest => dest.Description,
                     model => model.Description)
                .Map(dest => dest.State,
                     model => model.State)
                .Map(dest => dest.IsDeleted,
                     model => model.IsDeleted)
                .Map(dest => dest.CreatedAt,
                     model => model.CreatedAt)
                .Map(dest => dest.DeletedAt,
                     model => model.DeletedAt)
                .Map(dest => dest.ExecuteAt,
                     model => model.ExecuteAt)
                .Map(dest => dest.ExecutedAt,
                     model => model.ExecutedAt);

            TypeAdapterConfig<Task, TaskListItemModel>
                .NewConfig()
                .Map(dest => dest.Title,
                     model => model.Title)
                .Map(dest => dest.State,
                     model => model.State);
        }

        #endregion
    }
}
