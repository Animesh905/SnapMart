using SnapMart.Domain.Primitives;
using SnapMart.Domain.ValueObjects;

namespace SnapMart.Domain.Entities;
public sealed class Member : AggregateRoot
{
    private Member(Guid id,
        FirstName FirstName,
        MiddleName MiddleName,
        LastName LastName,
        PhoneNo PhoneNo,
        bool isActive,
        Email Email,
        string CreatedBy) 
        : base(id)
    {
        this.FirstName = FirstName;
        this.MiddleName = MiddleName;
        this.LastName = LastName;
        this.PhoneNo = PhoneNo;
        this.isActive = isActive;
        this.Email = Email;
        CreatedAt = DateTime.UtcNow;
        this.CreatedBy = CreatedBy;
    }
    private Member()
    {
    }

    public FirstName FirstName { get; set; }
    public MiddleName MiddleName { get; set; }
    public LastName LastName { get; set; }
    public Email Email { get; set; }
    public PhoneNo PhoneNo { get; set; }
    public bool isActive { get; set; } = true;
    public DateTime CreatedAt { get; private set; }
    public string CreatedBy { get; private set; }

    public static Member Create(
        Guid id,
        FirstName firstName,
        MiddleName middleName,
        LastName lastName,
        PhoneNo phoneNo,
        bool isActive,
        Email email,
        string CreatedBy
        )
    {
        var member = new Member(
            id,
            firstName,
            middleName,
            lastName,
            phoneNo,
            isActive,
            email,
            CreatedBy
            );

        member.RaiseDomainEvent(new MemberRegisteredDomainEvent(member.Id));

        return member;
    }
}
