﻿using DM.Shared.Application.Commands;

namespace DM.Modules.Tasks.Application.Commands.TaskLists
{
    public record RenameTaskList(Guid id, string title) : ICommand;
}
