using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.Massages.Commands.DeleteMasage
{
    public class DeleteMassageCommand : IRequest
    {
        public string Id { get; set; }
        public DeleteMassageCommand(string id)
        {
            Id = id;
        }
    }
}
