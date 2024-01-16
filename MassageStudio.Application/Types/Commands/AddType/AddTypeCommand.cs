using MassageStudio.Application.Types.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.Types.Commands.AddType
{
    public class AddTypeCommand : MassageTypeDto, IRequest
    {
    }
}
