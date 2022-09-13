using Application.Features.Githubs.Models;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Githubs.Queries.GetListGithub
{
    public class GetListGithubQuery:IRequest<GithubListModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
