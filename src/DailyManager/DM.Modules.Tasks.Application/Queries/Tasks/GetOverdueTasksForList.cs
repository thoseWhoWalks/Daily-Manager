﻿using DM.Modules.Tasks.Shared.Models.Tasks;
using DM.Shared.Application.Queries;

namespace DM.Modules.Tasks.Application.Queries.Tasks
{
    public class GetOverdueTasksForList : IQuery<IEnumerable<TaskModel>>
    {
        public Guid ListId { get; set; }
    }
}
