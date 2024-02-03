using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.ApplicationUser.Dtos
{
    public class ApplicationUserDetailsDto
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public IEnumerable<string> Roles { get; set; } = new List<string>();
        //lista masazy - TODO
    }
}
