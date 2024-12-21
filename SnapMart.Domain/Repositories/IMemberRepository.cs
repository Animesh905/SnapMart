using SnapMart.Domain.Entities.MemberEntities;
using SnapMart.Domain.ValueObjects;

namespace SnapMart.Domain.Repositories;

public interface IMemberRepository
{
    Task<bool> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken = default);
    void Add(Member member);

    void Add(MemberCredential memberCredential);
}
