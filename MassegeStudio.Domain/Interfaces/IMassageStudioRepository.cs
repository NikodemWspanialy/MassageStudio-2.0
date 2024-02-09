using MassageStudio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Domain.Interfaces
{
    public interface IMassageStudioRepository
    {
        Task AddTypeAsync(Domain.Entities.Type type);
        Task<Domain.Entities.Type?> GetTypeByNameAsync(string name);
        Task<IEnumerable<Entities.Type>> GetAllTypesAsync();
        Task SaveChangesAsync();
        void DeleteType(string name);
        Task<IEnumerable<Entities.Massage>> GetPreviousMassagesAsync(DateTime date);
        Task<IEnumerable<Entities.Massage>> GetAllMassagesAsync(DateTime dateTime);
        Task<Entities.Massage?> GetMassageByIsAsync(string id);
        Task<string> CreateMassageEmptyAsync(Entities.Massage massage);
        Task DeleteMassage(string id);
        IEnumerable<Massage> GetMassages(Func<Massage, bool> func);
    }
}
