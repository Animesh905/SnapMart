using SnapMart.Application.Abstractions.Messaging;
using SnapMart.Domain.Entities.MemberEntities;
using SnapMart.Domain.Errors;
using SnapMart.Domain.Repositories;
using SnapMart.Domain.Shared;
using SnapMart.Domain.ValueObjects;
using SnapMart.Domain.ValueObjects.MemberValueObjects;

namespace SnapMart.Application.Members.Commands;

internal sealed class CreateMemberCommandHandler : ICommandHandler<CreateMemberCommand, Guid>
{
    private readonly IMemberRepository _memberRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateMemberCommandHandler(
        IMemberRepository memberRepository,
        IUnitOfWork unitOfWork)
    {
        _memberRepository = memberRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> Handle(CreateMemberCommand command, CancellationToken cancellationToken)
    {
        Result<FirstName> firstnameresult = FirstName.Create(command.FirstName);
        Result<MiddleName> middlename = MiddleName.Create(command.MiddleName);
        Result<LastName> lastname = LastName.Create(command.LastName);
        Result<Email> email = Email.Create(command.Email);
        Result<PhoneNo> phoneno = PhoneNo.Create(command.MobileNumber);
        Result<PasswordHash> passwordHash = PasswordHash.Create(command.Password);

        if(!await _memberRepository.IsEmailUniqueAsync(email.Value, cancellationToken))
        {
            return Result.Failure<Guid>(DomainErrors.Member.EmailAlreadyInUse);
        }

        var id = Guid.NewGuid(); 

        var member = Member.Create(
            id,
            firstnameresult.Value,
            middlename.Value,
            lastname.Value,
            phoneno.Value,
            isActive: true,
            email.Value,
            "1"
            );

        var membercredential = MemberCredential.Create(
            id,
            passwordHash.Value,
            passwordHash.Value.Salt
            );

        _memberRepository.Add(member);

        _memberRepository.Add(membercredential);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return member.Id;
    }
}
