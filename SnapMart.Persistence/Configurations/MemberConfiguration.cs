using Microsoft.EntityFrameworkCore;
using SnapMart.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SnapMart.Persistence.Constants;
using SnapMart.Domain.ValueObjects;

namespace SnapMart.Persistence.Configurations;

internal sealed class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.ToTable(TableNames.tbl_Members);

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.FirstName)
            .HasConversion(x => x.Value, v => FirstName.Create(v).Value)
            .HasMaxLength(FirstName.MaxLength)
            .IsRequired();

        builder
            .Property(x => x.MiddleName)
            .HasConversion(x => x.Value, v => MiddleName.Create(v).Value)
            .HasMaxLength(MiddleName.MaxLength)
            .IsRequired();

        builder
            .Property(x => x.LastName)
            .HasConversion(x => x.Value, v => LastName.Create(v).Value)
            .HasMaxLength (LastName.MaxLength)
            .IsRequired();

        builder
            .Property(x => x.Email)
            .HasConversion(x => x.Value, v => Email.Create(v).Value)
            .IsRequired();

        builder
            .Property(x => x.PhoneNo)
            .HasConversion(x => x.Value, v => PhoneNo.Create(v).Value)
            .HasMaxLength(PhoneNo.MaxLength)
            .IsRequired();

        builder
            .Property(x => x.isActive)
            .HasDefaultValue(true)
            .IsRequired();

        builder
            .HasIndex(x => x.Email).IsUnique();

        builder
            .Property(x => x.CreatedBy)
            .HasMaxLength(20)
            .IsRequired();

        builder
            .Property(x => x.CreatedAt)
            .HasDefaultValue(DateTime.UtcNow)
            .IsRequired();
    }
}
