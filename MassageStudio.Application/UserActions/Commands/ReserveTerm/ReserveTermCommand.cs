using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.UserActions.Commands.ReserveTerm
{
    public class ReserveTermCommand : IRequest<IdentityResult>
    {
        public string Id { get; set; }

        public ReserveTermCommand(string id)
        {
            Id = id;
        }
    }
}
