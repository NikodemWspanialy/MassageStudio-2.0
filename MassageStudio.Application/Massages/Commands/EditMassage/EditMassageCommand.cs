using MassageStudio.Application.Massages.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.Massages.Commands.EditMassage
{
    public class EditMassageCommand : IRequest
    {
        public EditMassageDto Massage { get; set; }
        public EditMassageCommand(EditMassageDto massage)
        {
            Massage = massage;
        }
    }
}
