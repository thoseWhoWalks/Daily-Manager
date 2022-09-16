using DM.Module.Users.Context;
using DM.Shared.Infrastructure.Events;

namespace DM.Modules.Users.Events
{
    internal class UserEventDispatcher : EventDispatcher, IUserEventDispatcher
    {
        public UserEventDispatcher(UserDbContext dbContext) : base(dbContext)
        {
        }
    }
}
