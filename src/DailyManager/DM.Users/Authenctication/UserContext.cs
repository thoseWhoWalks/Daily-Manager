using DM.Module.Users.Models;

namespace DM.Module.Users.Authenctication
{
    public sealed class UserContext : IUserContext
    {
        #region Private fields
        private readonly AuthUserModel _user;
        #endregion

        public Guid UserId => _user.Id;

        public UserContext(AuthUserModel user)
        {
            _user = user;
        }
    }
}
