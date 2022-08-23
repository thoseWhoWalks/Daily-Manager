using DM.Modules.Tasks.Core.Aggregates;
using DM.Shared.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DM.Modules.Tasks.Infrastructure.Configurations
{
    internal class AuthorConfiguration : Configuration<Author>
    {
        public override void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(u => u.Login)
                .HasMaxLength(LoginMaxLength)
                .IsRequired();

            SetDateType(builder.Property(u => u.DeletedAt));
        }
    }
}
