using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Domain.Interfaces
{
    public interface IMassageTypeRepository
    {
        Task AddTypeAsync(Domain.Entities.Type type);
        void DeleteType(string name);
        Task<IEnumerable<Domain.Entities.Type>> GetAllTypesAsync();
        Task<Domain.Entities.Type?> GetTypeByIdAsync(int id);
        Task<Domain.Entities.Type?> GetTypeByNameAsync(string name);
        Task SaveChangesAsync();
    }
}
