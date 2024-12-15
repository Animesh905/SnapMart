using SnapMart.Domain.Primitives;

namespace SnapMart.Domain;
public sealed record MemberRegisteredDomainEvent(Guid MemberId) : IDomainEvent;
