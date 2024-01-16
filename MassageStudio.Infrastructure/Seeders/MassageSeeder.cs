using MassageStudio.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Infrastructure.Seeders
{
    public class MassageSeeder
    {
        private readonly MassageStudioDbContext context;

        public MassageSeeder(MassageStudioDbContext context)
        {
            this.context = context;
        }
        public async Task Seed()
        {
            if(await context.Database.CanConnectAsync())
            {
                if (!context.Massages.Any())
                {
                    var massage = new Domain.Entities.Massage()
                    {
                        Free = true,
                        Type = new()
                        {
                            Name = "masaz test",
                            Description = "opis test",
                            Price = 100,
                            Time = 60,
                        },
                        MasseurName = "Mariolka",
                        Date = DateTime.Now
                    };
                    context.Massages.Add(massage);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
