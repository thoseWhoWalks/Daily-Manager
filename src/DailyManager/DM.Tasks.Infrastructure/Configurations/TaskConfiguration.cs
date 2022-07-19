using DM.Shared.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = DM.Modules.Tasks.Core.Aggregates.Task;

namespace DM.Modules.Tasks.Infrastructure.Configurations
{
    internal class TaskConfiguration : Configuration<Task>
    {
        public override void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(u => u.Title)
                .HasMaxLength(TitleMaxLength)
                .IsRequired();
            builder.Property(u => u.Description)
                .HasMaxLength(DescriptionMaxLength)
                .IsRequired();

            SetDateType(builder.Property(u => u.CreatedAt));
            SetDateType(builder.Property(u => u.DeletedAt));
            SetDateType(builder.Property(u => u.ExecuteAt));
            SetDateType(builder.Property(u => u.ExecutedAt));
        }
    }
}
