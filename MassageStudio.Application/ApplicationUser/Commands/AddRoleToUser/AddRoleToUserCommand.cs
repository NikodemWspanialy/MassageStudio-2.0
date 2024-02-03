using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.ApplicationUser.Commands.AddRoleToUser
{
    public class AddRoleToUserCommand : IRequest
    {
        public string Id { get; set; }
        public string Role { get; set; }
        public AddRoleToUserCommand(string id, string role)
        {
            Id = id;
            Role = role;
        }
    }
}
