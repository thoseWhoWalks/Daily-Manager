using DM.Module.Users.Entities;
using DM.Shared.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DM.Module.Users.Configurations
{
    internal class UserConfiguration : Configuration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Login)
                .HasMaxLength(LoginMaxLength)
                .IsRequired();
            builder.Property(u => u.HashPassword)
                .HasMaxLength(HashMaxLength)
                .IsRequired();
            builder.Property(u => u.PasswordSalt)
                .HasMaxLength(SaltMaxLength)
                .IsRequired();

            SetDateType(builder.Property(u => u.CreatedAt));
            SetDateType(builder.Property(u => u.UpdatedAt));
            SetDateType(builder.Property(u => u.DeletedAt));
        }
    }
}
