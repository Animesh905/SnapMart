using SnapMart.Domain.Shared;

namespace SnapMart.Domain.ValidationError.Members;

public static class EmailErrors
{
    public static readonly Error Empty = Error.Validation("Email.Empty", "Email is Empty");
}
