using Microsoft.AspNetCore.Identity;
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
        public string LastName { get; set; }

        public CurrentUser(string id, string email, string name,string lastName, IEnumerable<string> roles)
        {
            Id = id;
            Email = email;
            Roles = roles;
            Name = name;
            LastName = lastName;
        }
        public bool IsInRole(string role) => Roles.Contains(role);
    }
}
