using Application.Features.Technologies.Models;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Queries.GetListTechnologyByDynamic
{
    public class GetListTechnologyByDynamicQuery:IRequest<TechnologyListModel>
    {
        public Dynamic Dynamic  { get; set; }
        public PageRequest PageRequest { get; set; }
    }
}
