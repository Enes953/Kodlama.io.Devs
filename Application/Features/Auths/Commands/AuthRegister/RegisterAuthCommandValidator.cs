using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.AuthRegister
{
    public class RegisterAuthCommandValidator: AbstractValidator<RegisterAuthCommand>
    {
        public RegisterAuthCommandValidator()
        {
        RuleFor(r => r.Email).NotEmpty();
        RuleFor(r => r.Password).NotEmpty();
        RuleFor(r => r.FirstName).NotEmpty();
        RuleFor(r => r.LastName).NotEmpty();

        }
        
    }
}
