using SnapMart.Domain.Errors;
using SnapMart.Domain.Primitives;
using SnapMart.Domain.Shared;

namespace SnapMart.Domain.ValueObjects;

public sealed class PhoneNo : ValueObject
{
    public const int MaxLength = 10;
    public string Value { get; }
    private PhoneNo(string value) => this.Value = value;

    public static Result<PhoneNo> Create(string PhoneNo)
    {
        if (string.IsNullOrWhiteSpace(PhoneNo))
        {
            return Result.Failure<PhoneNo>(DomainErrors.PhoneNo.Empty);
        }

        if (PhoneNo.Length > MaxLength)
        {
            return Result.Failure<PhoneNo>(DomainErrors.PhoneNo.TooLong);
        }

        return new PhoneNo(PhoneNo);
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return this;
    }
}
