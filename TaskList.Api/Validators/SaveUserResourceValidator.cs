using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskList.Api.Resources;

namespace TaskList.Api.Validators
{
    public class SaveUserResourceValidator : AbstractValidator<SaveUserResource>
    {
        public SaveUserResourceValidator()
        {
            RuleFor(u => u.LastName)
                .NotEmpty()
                .MaximumLength(300);

            RuleFor(u => u.FirstName)
                .NotEmpty()
                .MaximumLength(300);

            RuleFor(u => u.Login)
                .NotEmpty()
                .MaximumLength(300);

            RuleFor(u => u.Password)
                .NotEmpty()
                .MaximumLength(300);
        }
    }
}
