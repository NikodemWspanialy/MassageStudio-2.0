using MassageStudio.Application.Massages.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.Massages.Queries.GetFutureMassages
{
    public class GetFutureMassagesQuery : IRequest<IEnumerable<MassageToListDto>>
    {
    }
}
