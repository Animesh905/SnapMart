using SnapMart.Domain.Errors;
using SnapMart.Domain.Primitives;
using SnapMart.Domain.Shared;

namespace SnapMart.Domain.ValueObjects.MemberValueObjects;

public sealed class PasswordHash : ValueObject
{
    private PasswordHash(string value, string saltValue)
    { 
        Value = value; 
        Salt = saltValue;
    }
    public string Value { get; }
    public string Salt { get; }

    public static Result<PasswordHash> Create(string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(passwordHash))
        {
            return Result.Failure<PasswordHash>(DomainErrors.Password.Empty);
        }

        var salt = PasswordHelper.GenerateSalt();

        var newPasswordHash = PasswordHelper.HashPassword(passwordHash, salt);

        return new PasswordHash(newPasswordHash, salt);
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return this;
    }
}
