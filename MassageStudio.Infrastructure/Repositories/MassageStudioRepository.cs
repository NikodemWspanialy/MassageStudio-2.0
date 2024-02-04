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
    internal class MassageStudioRepository : IMassageStudioRepository
    {
        private readonly MassageStudioDbContext dbContext;

        public MassageStudioRepository(MassageStudioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddTypeAsync(Domain.Entities.Type type)
        {
            await dbContext.MassageTypes.AddAsync(type);
            await dbContext.SaveChangesAsync();
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

        public void DeleteMassage(string id)
        {
            var massage = dbContext.Massages.FirstOrDefault(m => m.Id == id);
            if(massage != null)
            {
                dbContext.Massages.Remove(massage);
                dbContext.SaveChanges();
            }
            throw new Exception($"can not delete massage with id = {id}");
        }

        public void DeleteType(string name)
        {
            var type = dbContext.MassageTypes.FirstOrDefault(t => t.Name == name);
            if (type != null)
            {
                dbContext.MassageTypes.Remove(type);
                dbContext.SaveChanges();
            }
        }

        public async Task<IEnumerable<Massage>> GetAllMassagesAsync()
        {
            return await dbContext.Massages.ToListAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Type>> GetAllTypesAsync()
        {
            return await dbContext.MassageTypes.ToListAsync();
        }

        public async Task<Massage?> GetMassageByIsAsync(string id)
            => await dbContext.Massages.FirstOrDefaultAsync(m => m.Id == id);

        public async Task<Domain.Entities.Type?> GetTypeByNameAsync(string name)
            => await dbContext.MassageTypes.FirstOrDefaultAsync(t => t.Name == name);

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
