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
        Task<IEnumerable<Entities.Massage>> GetAllMassagesAsync();
        Task<Entities.Massage?> GetMassageByIsAsync(string id);
        Task<string> CreateMassageEmptyAsync(Entities.Massage massage);
        void DeleteMassage(string id);
    }
}
