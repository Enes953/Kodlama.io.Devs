using Application.Features.Githubs.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Githubs.Commands.DeleteGithub
{
    public class DeleteGithubCommand:IRequest<DeletedGithubDto>
    {
        public int Id { get; set; }
    }
}
