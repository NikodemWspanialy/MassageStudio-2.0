using MassageStudio.Application.Types.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.Types.Queries.GetTypeByName
{
    public class GetTypeByNameQuery :  IRequest<MassageTypeDto>
    {
        public string Name { get; set; }
        public GetTypeByNameQuery(string name)
        {
            Name = name;
        }
    }
}
