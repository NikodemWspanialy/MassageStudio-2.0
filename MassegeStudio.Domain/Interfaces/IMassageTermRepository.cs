using MassageStudio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Domain.Interfaces
{
    public interface IMassageTermRepository
    {
        Task<string> CreateMassageEmptyAsync(Massage massage);
        Task DeleteMassage(string id);
        Task<IEnumerable<Massage>> GetAllMassagesAsync(DateTime dateTime);
        Task<Massage?> GetMassageByIsAsync(string id);
        IEnumerable<Massage> GetMassages(Func<Massage, bool> func);
        Task<IEnumerable<Massage>> GetPreviousMassagesAsync(DateTime date);
        Task SaveChangesAsync();
    }
}
