using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.Massages.Dtos
{
    public class EditMassageDto
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public bool Free { get; set; }
    }
}
