using MassageStudio.Domain.Entities;
using MassageStudio.Domain.Interfaces;
using MassageStudio.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Infrastructure.Repositories
{
    internal class MassageTermRepository : IMassageTermRepository
    {
        private readonly MassageStudioDbContext dbContext;

        public MassageTermRepository(MassageStudioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<string> CreateMassageEmptyAsync(Massage massage)
        {
            try
            {
                await dbContext.AddAsync(massage);
                await dbContext.SaveChangesAsync();
                return massage.Id;
            }
            catch
            {
                throw new Exception("Cant add new massage to database");
            }
        }

        public async Task DeleteMassage(string id)
        {
            var massage = await dbContext.Massages.FirstOrDefaultAsync(x => x.Id == id);
            if (massage != null)
            {
                dbContext.Massages.Remove(massage);
                dbContext.SaveChanges();
                return;
            }
            throw new Exception("Massage instance does not exist");

        }



        public async Task<IEnumerable<Massage>> GetPreviousMassagesAsync(DateTime date)
        {
            return await dbContext.Massages.Where(m => m.Date < date).OrderBy(m => m.Date).ToListAsync();
        }

        public async Task<IEnumerable<Massage>> GetAllMassagesAsync(DateTime dateTime)
        {
            return await dbContext.Massages.Where(m => m.Date > dateTime).OrderBy(m => m.Date).ToArrayAsync();
        }


        public async Task<Massage?> GetMassageByIsAsync(string id)
            => await dbContext.Massages.FirstOrDefaultAsync(m => m.Id == id);


        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public IEnumerable<Massage> GetMassages(Func<Massage, bool> func)
        {
            return dbContext.Massages.Where(func).ToList();
        }

    }
}
