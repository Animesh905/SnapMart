using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SnapMart.Persistence.Constants;
using SnapMart.Persistence.Outbox;

namespace SnapMart.Persistence.Configurations;

internal class OutboxMessageConfiguration
{
    public void Configure(EntityTypeBuilder<OutboxMessage> builder)
    {
        // Table name
        builder.ToTable(TableNames.tbl_OutboxMessage);

        // Primary key
        builder.HasKey(x => x.Id);

        // Properties
        builder.Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedNever(); // Ensures Guid is provided, not auto-generated

        builder.Property(x => x.OccurredOnUtc)
            .IsRequired();

        builder.Property(x => x.Type)
            .IsRequired()
            .HasMaxLength(255); // Assuming a max length for event type

        builder.Property(x => x.Content)
            .IsRequired();

        // Indexes (Optional)
        builder.HasIndex(x => x.OccurredOnUtc)
            .HasDatabaseName("IX_OutboxMessages_OccurredOnUtc");
    }
}
