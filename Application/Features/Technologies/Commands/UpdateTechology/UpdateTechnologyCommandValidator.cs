using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.UpdateTechology
{
    public class UpdateTechnologyCommandValidator:AbstractValidator<UpdateTechnologyCommand>
    {
        public UpdateTechnologyCommandValidator()
        {
            RuleFor(t => t.Id).NotEmpty();
            RuleFor(t => t.Name).NotEmpty();
            RuleFor(t => t.ProgrammingLanguageId).NotEmpty();
        }
    }
    
}
