using DM.Module.Users.Context;
using DM.Module.Users.Entities;
using DM.Module.Users.Exceptions;
using DM.Module.Users.Mapping;
using DM.Module.Users.Models;
using DM.Shared.Infrastructure.Helpers;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace DM.Module.Users.Services
{
    internal class UserService : IUserService
    {
        #region Dependencies

        private readonly UserDbContext _dbContext;

        #endregion

        public UserService(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserModel? GetById(UserModel model)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == model.Id);
            if (user is null) return null;

            if (user.IsDeleted) throw new UserDeletedException(user.Login);
            return user.Adapt<UserModel>();
        }

        public async Task<UserModel?> GetByIdAsync(UserModel model)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (user is null) return null;

            if (user.IsDeleted) throw new UserDeletedException(user.Login);
            return user.Adapt<UserModel>();
        }

        public void Create(UserToCreateModel model)
        {
            if (model is null) throw new ArgumentNullException(nameof(model));
            if(_dbContext.Users.Any(x => x.Login == model.Login))
                throw new LoginUsedExeption(model.Login);

            var user = model.Adapt<User>();
            var saltedHash = CryptoHelper.GenerateSaltedHash(model.Password);
            user.HashPassword = saltedHash.Hash;
            user.PasswordSalt = saltedHash.Salt;

            _dbContext.Add(user);
            _dbContext.SaveChanges();
        }

        public async Task CreateAsync(UserToCreateModel model)
        {
            if (model is null) throw new ArgumentNullException(nameof(model));
            if (await _dbContext.Users.AnyAsync(x => x.Login == model.Login)) 
                throw new LoginUsedExeption(model.Login);

            var user = model.Adapt<User>();
            var saltedHash = CryptoHelper.GenerateSaltedHash(model.Password);
            user.HashPassword = saltedHash.Hash;
            user.PasswordSalt = saltedHash.Salt;

            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public void Update(UserToUpdateModel model)
        {
            if (model is null) throw new ArgumentNullException(nameof(model));
                  
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == model.Id);
            ActionGuardAndThrow(user);

            user.Login = model.Login;
            user.UpdatedAt = DateTime.UtcNow;
            _dbContext.SaveChanges();
        }

        public async Task UpdateAsync(UserToUpdateModel model)
        {
            if (model is null) throw new ArgumentNullException(nameof(model));

            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == model.Id);
            ActionGuardAndThrow(user);

            user.Login = model.Login;
            user.UpdatedAt = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync();
        }

        public void ChangePassword(UserToChangePasswordModel model)
        {
            if (model is null) throw new ArgumentNullException(nameof(model));

            var user = _dbContext.Users.FirstOrDefault(x => x.Id == model.Id);
            ActionGuardAndThrow(user);

            var saltedHash = CryptoHelper.GenerateSaltedHash(model.Password);
            user.HashPassword = saltedHash.Hash;
            user.PasswordSalt = saltedHash.Salt;

            _dbContext.SaveChanges();
        }

        public async Task ChangePasswordAsync(UserToChangePasswordModel model)
        {
            if (model is null) throw new ArgumentNullException(nameof(model));

            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == model.Id);
            ActionGuardAndThrow(user);

            var saltedHash = CryptoHelper.GenerateSaltedHash(model.Password);
            user.HashPassword = saltedHash.Hash;
            user.PasswordSalt = saltedHash.Salt;

            user.UpdatedAt = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(Guid id)
        {
            if (id == default) throw new ArgumentOutOfRangeException(nameof(id)); 

            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            ActionGuardAndThrow(user);

            user.IsDeleted = true;
            user.DeletedAt = DateTime.Now;
            _dbContext.SaveChanges();
        }

        #region Private methods

        private void ActionGuardAndThrow(User? user)
        {
            if (user is null) throw new UserNotFoundException();
            if (user.IsDeleted) throw new UserDeletedException(user.Login);
        }

        #endregion
    }
}
