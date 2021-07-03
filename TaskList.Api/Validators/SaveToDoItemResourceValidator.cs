using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskList.Api.Resources;

namespace TaskList.Api.Validators
{
    public class SaveToDoItemResourceValidator : AbstractValidator<SaveToDoItemResource>
    {
        public SaveToDoItemResourceValidator()
        {
            RuleFor(t => t.Name)
                .NotEmpty()
                .MaximumLength(300);
        }
    }
}
