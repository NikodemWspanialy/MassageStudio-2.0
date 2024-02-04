using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.Massages.Dtos
{
    public class CreateMassagEmptyDto
    {
        public DateTime Date { get; set; }
        public string? MasseurName { get; set; }
        public string? MasseurId { get; set; }

        public CreateMassagEmptyDto()
        {
            
        }
        public CreateMassagEmptyDto(DateTime date, string name, string Id)
        {
            Date = date;
            MasseurName = name;
            MasseurId = Id;
        }
    }
}
