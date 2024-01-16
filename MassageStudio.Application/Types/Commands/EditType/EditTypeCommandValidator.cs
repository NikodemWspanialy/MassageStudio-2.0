using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.Types.Commands.EditType
{
    public class EditTypeCommandValidator : AbstractValidator<EditTypeCommand>
    {
        public EditTypeCommandValidator()
        {
            RuleFor(c => c.Price)
                .NotEmpty()
                .NotNull();
            RuleFor(c => c.Time)
                .NotEmpty()
                .NotNull();
        }
    }
}
