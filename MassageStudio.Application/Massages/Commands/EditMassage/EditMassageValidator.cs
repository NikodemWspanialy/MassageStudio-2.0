using FluentValidation;
using MassageStudio.Application.Massages.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.Massages.Commands.EditMassage
{
    public class EditMassageValidator : AbstractValidator<MassageDetailsDto>
    {
        public EditMassageValidator()
        {
            //rules
        }
    }
}
