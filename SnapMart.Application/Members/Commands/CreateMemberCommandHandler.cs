using SnapMart.Application.Abstractions.Messaging;
using SnapMart.Domain.Entities;
using SnapMart.Domain.Errors;
using SnapMart.Domain.Repositories;
using SnapMart.Domain.Shared;
using SnapMart.Domain.ValueObjects;

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

        if(!await _memberRepository.IsEmailUniqueAsync(email.Value, cancellationToken))
        {
            return Result.Failure<Guid>(DomainErrors.Member.EmailAlreadyInUse);
        }

        var member = Member.Create(
            Guid.NewGuid(),
            firstnameresult.Value,
            middlename.Value,
            lastname.Value,
            phoneno.Value,
            isActive: true,
            email.Value,
            "1"
            );

        _memberRepository.Add(member);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return member.Id;
    }
}
