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
        RuleFor(r => r.UserForRegisterDto.Email).NotEmpty();
        RuleFor(r => r.UserForRegisterDto.Password).NotEmpty();
        RuleFor(r => r.UserForRegisterDto.FirstName).NotEmpty();
        RuleFor(r => r.UserForRegisterDto.LastName).NotEmpty();

        }
        
    }
}
