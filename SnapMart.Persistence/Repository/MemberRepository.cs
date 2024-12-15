using Microsoft.EntityFrameworkCore;
using SnapMart.Domain.Entities;
using SnapMart.Domain.Repositories;
using SnapMart.Domain.ValueObjects;

namespace SnapMart.Persistence.Repository;

public sealed class MemberRepository : IMemberRepository
{
    private readonly ApplicationDbContext _dbContext;
    public MemberRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

    public void Add(Member member) => _dbContext.Set<Member>().Add(member);

    public async Task<bool> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken = default) =>
        !await _dbContext.Set<Member>().AnyAsync(x => x.Email == email, cancellationToken);
}
