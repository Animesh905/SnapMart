using SnapMart.Domain.Primitives;

namespace SnapMart.Domain.Entities;
public sealed class Member : Entity
{
    public Member(Guid id,
        string FirstName,
        string MiddleName,
        string LastName,
        long PhoneNo,
        bool isActive,
        string Email) 
        : base(id)
    {
        this.FirstName = FirstName;
        this.MiddleName = MiddleName;
        this.LastName = LastName;
        this.PhoneNo = PhoneNo;
        this.isActive = isActive;
        this.Email = Email;
    }

    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public long PhoneNo { get; set; }
    public bool isActive { get; set; } = true;
}
