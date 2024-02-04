using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.Massages.Dtos
{
    public class MassageDetailsDto 
    {
        public string Id { get; set; }
        public Type Type { get; set; } = default!;
        public DateTime Date { get; set; }
        public DateTime SetupDate { get; set; } = DateTime.Now;
        public string? MasseurName { get; set; }
        public string? MasseurLastName { get; set; }
        public string? MasseurId { get; set; }
        public bool Free { get; set; } = true;
        public string? ClientName { get; set; }
        public string? ClientLastName { get; set; }
        public string? ClientId { get; set; }
    }
}
