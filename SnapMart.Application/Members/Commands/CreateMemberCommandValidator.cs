using FluentValidation;
using SnapMart.Domain.Shared;
using SnapMart.Domain.ValidationError.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapMart.Application.Members.Commands
{
    internal class CreateMemberCommandValidator : AbstractValidator<CreateMemberCommand>
    {
        public CreateMemberCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(EmailErrors.Empty.Description)
                .WithErrorCode(EmailErrors.Empty.Code);

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(20)
                .WithMessage("Name Should not be empty"); ;

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(20)
                .WithMessage("Name Should not be empty");
        }
    }
}
