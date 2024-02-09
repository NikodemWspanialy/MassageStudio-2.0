using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.ApplicationUser.Commands.DeleteUserRole
{
    public class DeleteUserRoleCommand : IRequest
    {
        public string Id { get; set; }
        public string Role { get; set; }
        public DeleteUserRoleCommand(string id, string role)
        {
            Id = id;
            Role = role;
        }
    }
}
