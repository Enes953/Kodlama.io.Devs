using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Githubs.Commands.DeleteGithub
{
    public class DeleteGithubCommandValidator:AbstractValidator<DeleteGithubCommand>
    {
        public DeleteGithubCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}
