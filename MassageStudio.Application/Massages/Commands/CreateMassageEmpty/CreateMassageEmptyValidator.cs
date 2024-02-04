using FluentValidation;
using MassageStudio.Application.Massages.Dtos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.Massages.Commands.CreateMassageEmpty
{
    public class CreateMassageEmptyValidator : AbstractValidator<CreateMassagEmptyDto>
    {
        public CreateMassageEmptyValidator()
        {
            RuleFor(c => c.Date)
                .NotEmpty()
                .Custom((date, context) =>
                {
                    if(date < DateTime.Now)
                    {
                        context.AddFailure("Date must be point in future");
                    }
                });
        }
    }
}
