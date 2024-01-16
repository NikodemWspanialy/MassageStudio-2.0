using MassageStudio.Application.Types.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.Types.Queries.GetAllTypes
{
    public class GetAllTypesQuery : IRequest<IEnumerable<MassageTypeDto>>
    {
    }
}
