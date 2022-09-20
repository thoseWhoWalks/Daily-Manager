using DM.Module.Users.Models;

namespace DM.Modules.Users.Authenctication
{
    // TODO: Implement Refresh token persistance;
    internal interface IAuthenticator
    {
        AuthUserModel AuthWithCredentials(string login, string password);
        Task<AuthUserModel> AuthWithCredentialsAsync(string login, string password);
        AuthUserModel AuthWithAccessToken(string accessToken);
        Task<AuthUserModel> AuthWithAccessTokenAsync(string accessToken);
    }
}
