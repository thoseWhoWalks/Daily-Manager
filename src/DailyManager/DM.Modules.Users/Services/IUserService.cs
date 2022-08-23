using DM.Module.Users.Models;
using DM.Shared.Core.Services;

namespace DM.Module.Users.Services
{
    internal interface IUserService :
        IReadableService<UserModel>,
        ICreateableService<UserToCreateModel>,
        IUpdateableService<UserToUpdateModel>,
        IDeleteableService
    {
        void ChangePassword(UserToChangePasswordModel model);
        Task ChangePasswordAsync(UserToChangePasswordModel model);
    }
}
