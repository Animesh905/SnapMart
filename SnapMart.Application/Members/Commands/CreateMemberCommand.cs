using SnapMart.Application.Abstractions.Messaging;

namespace SnapMart.Application.Members.Commands;

public sealed record CreateMemberCommand(
    string FirstName,
    string MiddleName,
    string LastName,
    string MobileNumber,
    string Email,
    string Password
) : ICommand<Guid>;

