using MassageStudio.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Infrastructure.Persistance
{
    public class MassageStudioDbContext : IdentityDbContext
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Domain.Entities.Massage> Massages { get; set; }
        public DbSet<Domain.Entities.Type> MassageTypes { get; set; }

        public MassageStudioDbContext(DbContextOptions<MassageStudioDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
        }
    }
}
