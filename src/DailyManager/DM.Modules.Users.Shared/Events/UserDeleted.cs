using DM.Shared.Core.Events;

namespace DM.Modules.Users.Shared.Events
{
    public record UserDeleted(Guid UserId, DateTime? DeletedAt) : IEvent;
}
