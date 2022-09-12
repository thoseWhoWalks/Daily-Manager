using DM.Shared.Core.Events;

namespace DM.Modules.Users.Shared.Events
{
    public record UserCreated(Guid UserId, string Login) : IEvent;
}
