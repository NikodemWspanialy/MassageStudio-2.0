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

namespace MassageStudio.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MassageStudioDbContext>(opt => 
            opt.UseSqlServer(configuration.GetConnectionString("MassageStudio"))
            );
            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.Stores.MaxLengthForKeys = 450;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 2;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<MassageStudioDbContext>();
            services.AddScoped<IMassageStudioRepository, MassageStudioRepository>();
            services.AddScoped<MassageSeeder>();
        }
    }
}
