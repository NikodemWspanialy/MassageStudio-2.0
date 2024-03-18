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
        //init values
        private const string NAME = "Anna";
        private const string LASTNAME = "Kowalska";
        private const string MASSAGE_TYPE = "kobido";

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
                        TypeName = MASSAGE_TYPE,
                        MasseurName = NAME,
                        MasseurLastName = LASTNAME,
                        Date = DateTime.Now
                    };
                    //context.Massages.Add(massage);
                    // context.SaveChangesAsync();
                }
            }
        }
    }
}
