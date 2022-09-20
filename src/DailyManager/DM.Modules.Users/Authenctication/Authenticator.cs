using DM.Module.Users.Context;
using DM.Module.Users.Entities;
using DM.Module.Users.Exceptions;
using DM.Module.Users.Models;
using DM.Shared.Infrastructure.Helpers;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DM.Modules.Users.Authenctication
{
    internal class Authenticator : IAuthenticator
    {
        #region Constants

        private const string UserIdClaimName = "id";

        #endregion

        #region Private fields

        private readonly TokenValidationParameters _jwtTokenValidationParams;
        private readonly SymmetricSecurityKey _jwtTokenSecret;

        #endregion

        #region Dependencies

        private readonly UserDbContext _dbContext;
        private readonly JwtOptions _jwtOptions;

        #endregion

        public Authenticator(
            UserDbContext dbContext,
            IOptions<JwtOptions> jwtOptions
            )
        {
            _dbContext = dbContext;
            _jwtOptions = jwtOptions.Value;

            _jwtTokenSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Secret));
            _jwtTokenValidationParams = new TokenValidationParameters
            {
                IssuerSigningKey = _jwtTokenSecret,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireAudience = false,
                ClockSkew = TimeSpan.Zero
            };
        }

        public AuthUserModel AuthWithCredentials(string login, string password)
        {
            if (string.IsNullOrEmpty(login)) throw new ArgumentNullException(nameof(login));
            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException(nameof(password));

            var dbUser = _dbContext.Users.FirstOrDefault(u => u.Login == login);
            ActionGuardAndThrow(dbUser);
            if (!CryptoHelper.IsHashValid(password, dbUser!.HashPassword, dbUser.PasswordSalt))
                throw new UserNotFoundException();

            var claims = BuildClaims(dbUser!);
            return BuildAuthModel(dbUser!, GenerateToken(claims));
        }

        public async Task<AuthUserModel> AuthWithCredentialsAsync(string login, string password)
        {
            if (string.IsNullOrEmpty(login)) throw new ArgumentNullException(nameof(login));
            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException(nameof(password));
          
            var dbUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Login == login);
            ActionGuardAndThrow(dbUser);
            if (!CryptoHelper.IsHashValid(password, dbUser!.HashPassword, dbUser.PasswordSalt))
                throw new UserNotFoundException();
            
            var claims = BuildClaims(dbUser!);
            return BuildAuthModel(dbUser, GenerateToken(claims));
        }

        public AuthUserModel AuthWithAccessToken(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken)) throw new ArgumentNullException(nameof(accessToken));

            var claims = new JwtSecurityTokenHandler()
                .ValidateToken(accessToken, _jwtTokenValidationParams, out var validatedToken);
            var userId = ParseClaims(claims);

            var dbUser = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
            ActionGuardAndThrow(dbUser);

            return BuildAuthModel(dbUser!, accessToken);
        }

        public async Task<AuthUserModel> AuthWithAccessTokenAsync(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken)) throw new ArgumentNullException(nameof(accessToken));

            var claims = new JwtSecurityTokenHandler()
               .ValidateToken(accessToken, _jwtTokenValidationParams, out var validatedToken);
            var userId = ParseClaims(claims);

            var dbUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            ActionGuardAndThrow(dbUser);

            return BuildAuthModel(dbUser!, accessToken);
        }

        #region Private methods

        private static void ActionGuardAndThrow(User? dbUser)
        {
            if (dbUser is null) throw new UserNotFoundException();
            if (dbUser.IsDeleted) throw new UserDeletedException(dbUser.Login);
        }

        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var token = new JwtSecurityToken(
                _jwtOptions.Issuer,
                _jwtOptions.Issuer,
                claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtOptions.ExpireIn),
                signingCredentials: new SigningCredentials(_jwtTokenSecret, SecurityAlgorithms.HmacSha256Signature)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private IEnumerable<Claim> BuildClaims(User dbUser)
            => new Claim[] { new Claim(UserIdClaimName, dbUser.Id.ToString()) };

        private Guid ParseClaims(ClaimsPrincipal claims)
            => Guid.Parse(claims.Claims.First(x => x.Type == UserIdClaimName).Value);

        private AuthUserModel BuildAuthModel(User dbUser, string token)
            => new AuthUserModel(dbUser.Adapt<UserModel>(), token);

        #endregion
    }
}
