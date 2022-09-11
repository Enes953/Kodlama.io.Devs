using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Githubs.Commands.CreateGithub
{
    public class CreateGithubCommandValidator:AbstractValidator<CreateGithubCommand>
    {
        public CreateGithubCommandValidator()
        {
            RuleFor(c => c.UserId).NotEmpty();
            RuleFor(c => c.Url).NotEmpty();
        }
    }
}
