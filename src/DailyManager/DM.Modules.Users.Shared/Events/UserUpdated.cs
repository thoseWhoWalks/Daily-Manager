using DM.Shared.Core.Events;

namespace DM.Modules.Users.Shared.Events
{
    public record UserUpdated(Guid UserId, string Login) : IEvent;
}
