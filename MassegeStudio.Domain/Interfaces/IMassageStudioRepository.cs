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
    }
}
