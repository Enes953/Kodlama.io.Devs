using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.AuthLogin
{
    public class LoginAuthCommandValidator: AbstractValidator<LoginAuthCommand>
    {
        public LoginAuthCommandValidator()
        {
            RuleFor(l => l.UserForLoginDto.Email).NotEmpty();
            RuleFor(l => l.UserForLoginDto.Email).EmailAddress();
            RuleFor(l => l.UserForLoginDto.Password).NotEmpty();
        }
    }
}
