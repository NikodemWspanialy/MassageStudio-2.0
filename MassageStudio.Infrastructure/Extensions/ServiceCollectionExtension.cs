using MassageStudio.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassageStudio.Domain.Interfaces;
using MassageStudio.Infrastructure.Repositories;
using MassageStudio.Infrastructure.Seeders;
using MassageStudio.Domain.Entities;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace MassageStudio.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MassageStudioDbContext>(opt => 
            opt.UseSqlServer(configuration.GetConnectionString("MassageStudio"))
            );
            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.Stores.MaxLengthForKeys = 450;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 2;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                options.SignIn.RequireConfirmedAccount = true;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<MassageStudioDbContext>();


            services.AddScoped<IMassageTermRepository, MassageTermRepository>();
            services.AddScoped<IMassageTypeRepository, MassageTypeRepository>();
            services.AddScoped<MassageSeeder>();
            services.AddScoped<AdminSeeder>();
        }
    }
}
