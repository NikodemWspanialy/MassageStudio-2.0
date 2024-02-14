using MassageStudio.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Infrastructure.Seeders
{
    public class AdminSeeder
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AdminSeeder(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task Seed()
        {
            var adminRole = roleManager.Roles.FirstOrDefaultAsync(r => r.Name == "Admin");
            var masseurRole = roleManager.Roles.FirstOrDefaultAsync(r => r.Name == "Masseur");
            if(adminRole == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if(masseurRole == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Masseur"));
            }
            var adminUser = userManager.FindByNameAsync("admin");
            if(adminUser == null)
            {
                var newUserAdmin = new ApplicationUser
                {
                    Name = "admin",
                    LastName = "admin",
                    Email = "admin@admin.com",
                };
                await userManager.CreateAsync(newUserAdmin,"password");
                await userManager.AddToRoleAsync(newUserAdmin, "Admin");
                await userManager.AddToRoleAsync(newUserAdmin, "Masseur");
            }
        }
    }
}
