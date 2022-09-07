using DM.Shared.OutBox.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DM.Shared.OutBox.Configurations
{
    internal class OutBoxMessageConfiguration : IEntityTypeConfiguration<OutBoxMessage>
    {
        #region Contants
        private const int TypeMaxLength = 256;
        private const int MessageMaxLength = 512;

        protected const string DateTimeTypeName = "datetime2";
        #endregion

        public void Configure(EntityTypeBuilder<OutBoxMessage> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(u => u.Type)
                .HasMaxLength(TypeMaxLength)
                .IsRequired();
            builder.Property(u => u.Message)
                .HasMaxLength(MessageMaxLength)
                .IsRequired();

            builder
                .Property(obm => obm.CreatedAt)
                .HasColumnType(DateTimeTypeName);
            builder
                .Property(obm => obm.ExecutedAt)
                .HasColumnType(DateTimeTypeName);
        }
    }
}
