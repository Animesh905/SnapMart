using SnapMart.Application.Abstractions.Messaging;
using SnapMart.Domain.Shared;

namespace SnapMart.Application.Members.Commands;

internal sealed class CreateMemberCommandHandler : ICommandHandler<CreateMemberCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateMemberCommand command, CancellationToken cancellationToken)
    {
        Guid memberId = Guid.NewGuid();

        return Result.Success(memberId);
    }
}
