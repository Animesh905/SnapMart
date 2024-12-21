using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SnapMart.Domain.Entities.MemberEntities;
using SnapMart.Domain.ValueObjects.MemberValueObjects;
using SnapMart.Persistence.Constants;

namespace SnapMart.Persistence.Configurations;

internal class MemberCredentialConfiguration : IEntityTypeConfiguration<MemberCredential>
{
    public void Configure(EntityTypeBuilder<MemberCredential> builder)
    {
        builder.ToTable(TableNames.tbl_MemberCredential);

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.PasswordSalt)
            .IsRequired()
            .HasMaxLength(128);

        builder
            .Property(x => x.PasswordHash)
            .HasConversion(x => x.Value, v => PasswordHash.Create(v).Value)
            .IsRequired();

        builder
            .Property(x => x.LastPasswordChange)
            .IsRequired();

        builder
            .HasOne<Member>()
            .WithOne()
            .HasForeignKey<MemberCredential>(x => x.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
