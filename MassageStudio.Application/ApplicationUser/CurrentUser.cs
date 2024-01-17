using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.ApplicationUser
{
    public class CurrentUser
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public string Name { get; set; }

        public CurrentUser(string id, string email, string name, IEnumerable<string> roles)
        {
            Id = id;
            Email = email;
            Roles = roles;
            Name = name;
        }
        public bool IsInRole(string role) => Roles.Contains(role);
    }
}
