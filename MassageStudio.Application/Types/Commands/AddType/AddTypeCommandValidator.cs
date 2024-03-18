using FluentValidation;
using MassageStudio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.Types.Commands.AddType
{
    public class AddTypeCommandValidator : AbstractValidator<AddTypeCommand>
    {
        public AddTypeCommandValidator(IMassageTypeRepository repository)
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(20)
                .Custom((name, context) =>
                {
                    var existingType = repository.GetTypeByNameAsync(name).Result;
                    if (existingType != null)
                    {
                        context.AddFailure("This massage type already exist");
                    }
                });
            RuleFor(c => c.Price)
                .NotEmpty()
                .NotNull();
            RuleFor(c => c.Time)
                .NotEmpty()
                .NotNull();
        }
    }
}
