using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.Massages.Dtos
{
    internal class AddMassageDto
    {
        public DateTime Date { get; set; }
        public DateTime SetupDate { get; set; } = DateTime.Now;
        public string? MasseurName { get; set; }
        public string? MasseurId { get; set; }
    }
}
