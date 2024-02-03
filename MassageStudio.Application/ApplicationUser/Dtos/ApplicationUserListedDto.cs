using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.ApplicationUser.Dtos
{
    public class ApplicationUserListedDto
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;

    }
}
