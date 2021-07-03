using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskList.Api.Resources;

namespace TaskList.Api.Validators
{
    public class SaveProjectResourceValidator : AbstractValidator<SaveProjectResource>
    {
        public SaveProjectResourceValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MaximumLength(300);
        }
    }
}
