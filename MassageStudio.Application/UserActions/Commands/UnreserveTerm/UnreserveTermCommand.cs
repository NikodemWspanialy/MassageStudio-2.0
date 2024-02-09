using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.UserActions.Commands.UnreserveTerm
{
    public class UnreserveTermCommand : IRequest<IdentityResult>
    {
        public string Id { get; set; }
        public UnreserveTermCommand(string id)
        {
            Id = id;
        }
    }
}
