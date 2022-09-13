using Application.Features.Githubs.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Githubs.Queries.GetByIdGithub
{
    public class GetByIdGithubQuery:IRequest<GithubGetByIdDto>
    {
        public int Id { get; set; }
    }
}
