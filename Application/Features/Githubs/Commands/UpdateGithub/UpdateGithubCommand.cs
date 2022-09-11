using Application.Features.Githubs.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Githubs.Commands.UpdateGithub
{
    public class UpdateGithubCommand:IRequest<UpdatedGithubDto>
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }
    }
}
