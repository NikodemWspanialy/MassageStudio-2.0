using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.Types.Commands.DeleteType
{
    public class DeleteTypeCommand : IRequest
    {
        public string Name { get; set; } = default!;
        public DeleteTypeCommand(string name)
        {
            this.Name = name;
        }
    }
}
