namespace SnapMart.WebApi.SmartWeb.Member.Contracts;

public sealed record RegisterMemberRequest(
    string FirstName,
    string LastName,
    string MobileNumber,
    string Email,
    string Password
    );

