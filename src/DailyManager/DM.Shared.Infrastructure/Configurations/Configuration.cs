using DM.Shared.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DM.Shared.Infrastructure.Configurations
{
    public abstract class Configuration<TEntity> : 
        IEntityTypeConfiguration<TEntity>
        where TEntity : class, IEntity
    {
        #region Constants

        protected const int LoginMaxLength = 128;
        protected const int HashMaxLength = 258;
        protected const int SaltMaxLength = 128;

        protected const string DateTypeName = "date";

        #endregion

        public abstract void Configure(EntityTypeBuilder<TEntity> builder);

        #region Configurators

        protected void SetDateType(PropertyBuilder<DateTime> builder)
        {
            builder.HasColumnType(DateTypeName);
        }

        protected void SetDateType(PropertyBuilder<DateTime?> builder)
        {
            builder.HasColumnType(DateTypeName);
        }

        #endregion
    }
}
