namespace Accommodation.Application.Facilities.Commands.CreateFacility
{
    using FluentValidation;

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
