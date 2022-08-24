using DM.Modules.Tasks.Core.Aggregates;
using DM.Shared.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DM.Modules.Tasks.Infrastructure.Configurations
{
    internal class TaskListConfiguration : Configuration<TaskList>
    {
        public override void Configure(EntityTypeBuilder<TaskList> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(u => u.Title)
                .HasMaxLength(TitleMaxLength)
                .IsRequired();
            builder.Property(u => u.Description)
                .HasMaxLength(DescriptionMaxLength)
                .IsRequired();

            builder.HasMany(tl => tl.Tasks)
                .WithOne()
                .HasForeignKey(t => t.ListId);
            builder.HasOne<Author>()
                .WithMany()
                .HasForeignKey(tl => tl.AuthorId);

            SetDateType(builder.Property(u => u.CreatedAt));
            SetDateType(builder.Property(u => u.DeletedAt));
        }
    }
}
