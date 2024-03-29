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
        // init values
        private const string ADMIN_ROLE = "Admin";
        private const string MASSEUR_ROLE = "Masseur";
        //admin params
        private const string NAME_ADMIN = "admin";
        private const string EMAIL_ADMIN = "admin@admin.com";
        private const string PASSWORD_ADMIN = "password";
        //masseur params
        private const string NAME_MASSEUR = "masseur";
        private const string EMAIL_MASSEUR = "masseur@masseur.com";
        private const string PASSWORD_MASSEUR = "password";
        //owner params
        private const string NAME_OWNER = "owner";
        private const string EMAIL_OWNER = "owner@owner.com";
        private const string PASSWORD_OWNER = "password";

        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AdminSeeder(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task Seed()
        {
            var adminRole = await roleManager.Roles.FirstOrDefaultAsync(r => r.Name == ADMIN_ROLE);
            var masseurRole = await roleManager.Roles.FirstOrDefaultAsync(r => r.Name == MASSEUR_ROLE);
            if(adminRole == null)
            {
                await roleManager.CreateAsync(new IdentityRole(ADMIN_ROLE));
            }
            if(masseurRole == null)
            {
                await roleManager.CreateAsync(new IdentityRole(MASSEUR_ROLE));
            }
            //seed admin 
            var adminUser = await userManager.FindByNameAsync(NAME_ADMIN);
            if(adminUser == null)
            {
                var newUserAdmin = new ApplicationUser
                {
                    Name = NAME_ADMIN,
                    LastName = NAME_ADMIN,
                    Email = EMAIL_ADMIN,
                    UserName = NAME_ADMIN,
                    EmailConfirmed = true,
                };
                await userManager.CreateAsync(newUserAdmin, PASSWORD_ADMIN);
                await userManager.AddToRoleAsync(newUserAdmin, ADMIN_ROLE);
            }
            //seed masseur 
            var masseurUser = await userManager.FindByNameAsync(NAME_MASSEUR);
            if (adminUser == null)
            {
                var newUserAdmin = new ApplicationUser
                {
                    Name = NAME_MASSEUR,
                    LastName = NAME_MASSEUR,
                    Email = EMAIL_MASSEUR,
                    UserName = NAME_MASSEUR,
                    EmailConfirmed = true,

                };
                var status = await userManager.CreateAsync(newUserAdmin, PASSWORD_MASSEUR);
                await userManager.AddToRoleAsync(newUserAdmin, MASSEUR_ROLE);
            }
            //seed owner 
            var ownerUser = await userManager.FindByNameAsync(NAME_OWNER);
            if (adminUser == null)
            {
                var newUserAdmin = new ApplicationUser
                {
                    Name = NAME_OWNER,
                    LastName = NAME_OWNER,
                    Email = EMAIL_OWNER,
                    UserName = NAME_OWNER,
                    EmailConfirmed = true,

                };
                await userManager.CreateAsync(newUserAdmin, PASSWORD_OWNER);
                await userManager.AddToRoleAsync(newUserAdmin, MASSEUR_ROLE);
                await userManager.AddToRoleAsync(newUserAdmin, ADMIN_ROLE);
            }
        }
    }
}
