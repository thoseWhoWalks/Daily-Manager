using DM.Shared.Core.Events;

namespace DM.Modules.Tasks.Core.Events.Authors
{
    public record AuthorDeleted(Guid AuthorId) : IEvent;
}
