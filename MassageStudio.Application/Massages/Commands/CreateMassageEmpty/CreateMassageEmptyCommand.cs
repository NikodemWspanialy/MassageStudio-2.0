using MassageStudio.Application.Massages.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.Massages.Commands.CreateMassageEmpty
{
    public class CreateMassageEmptyCommand : CreateMassagEmptyDto, IRequest<string?>
    {
        public CreateMassageEmptyCommand() : base()
        {
            
        }
    }
}
