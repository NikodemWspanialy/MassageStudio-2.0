using MassageStudio.Application.Massages.Dtos;
using MassageStudio.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.UserActions.Queries.GetMassages
{
    public class GetMassagesQuery : IRequest<IEnumerable<MassageToListDto>>
    {
        public Func<Massage, bool> Lambda { get; set; }

        public GetMassagesQuery(Func<Massage, bool> lambda)
        {
            Lambda = lambda;
        }
        public GetMassagesQuery()
        {
            Lambda = m => m.Id != null;
        }
    }
}
