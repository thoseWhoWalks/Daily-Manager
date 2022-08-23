using DM.Module.Users.Entities;
using DM.Module.Users.Models;
using DM.Shared.Application.Mapping;
using Mapster;

namespace DM.Module.Users.Mapping
{
    internal class MapsterConfig : IMapperConfig
    {
        public void Create()
        {
            CreateUserMap();
        }

        #region Private methods

        private void CreateUserMap()
        {
            TypeAdapterConfig<UserToCreateModel, User>
                .NewConfig()
                .Map(dest => dest.Login,
                     model => model.Login);

            TypeAdapterConfig<User, UserModel>
                .NewConfig()
                .Map(dest => dest.Id,
                     model => model.Id)
                .Map(dest => dest.Login,
                     model => model.Login)
                .Map(dest => dest.IsDeleted,
                     model => model.IsDeleted);
        }

        #endregion
    }
}
