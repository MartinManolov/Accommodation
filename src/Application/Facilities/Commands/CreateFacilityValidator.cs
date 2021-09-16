using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accommodation.Application.Facilities.Commands
{
    public class CreateFacilityValidator : AbstractValidator<CreateFacilityCommand>
    {
        public CreateFacilityValidator()
        {
            RuleFor(v => v.Name)
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(25);
        }
    }
}
