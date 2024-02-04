using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.Massages.Dtos
{
    public class MassageToListDto
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public bool Free { get; set; }
        public string MasseurName { get; set; }

        public MassageToListDto(string id, DateTime date, bool free, string massureName)
        {
            Id = id;
            Date = date;
            Free = free;
            MasseurName = massureName;
        }
    }
}
