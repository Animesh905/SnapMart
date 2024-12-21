using SnapMart.Domain.Primitives;
using SnapMart.Domain.ValueObjects.MemberValueObjects;

namespace SnapMart.Domain.Entities.MemberEntities;

public sealed class MemberCredential : AggregateRoot
{
    private MemberCredential(
        Guid id,
        PasswordHash PasswordHash,
        string PasswordSalt
        ) : base(id)
    {
        this.PasswordHash = PasswordHash;
        this.PasswordSalt = PasswordSalt;
        LastPasswordChange = DateTime.UtcNow;
    }

    private MemberCredential()
    {
    }
    public PasswordHash PasswordHash { get; set; }
    public string PasswordSalt { get; set; }
    public DateTime LastPasswordChange { get; private set; }

    public static MemberCredential Create(
        Guid id,
        PasswordHash passwordHash,
        string passwordsalt
        )
    {
        return new MemberCredential(
            id,
            passwordHash,
            passwordsalt);
    }
}
