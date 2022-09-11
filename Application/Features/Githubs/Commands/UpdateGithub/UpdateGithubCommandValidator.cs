using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Githubs.Commands.UpdateGithub
{
    public class UpdateGithubCommandValidator:AbstractValidator<UpdateGithubCommand>
    {
        public UpdateGithubCommandValidator()
        {
            RuleFor(u => u.Id).NotEmpty();
            RuleFor(u => u.UserId).NotEmpty();
            RuleFor(u => u.Url).NotEmpty();
        }
    }
}
