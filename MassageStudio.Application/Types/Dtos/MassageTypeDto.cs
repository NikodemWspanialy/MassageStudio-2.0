using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.Types.Dtos
{
    public class MassageTypeDto
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int Time { get; set; }
        public double Price { get; set; }
    }
}
