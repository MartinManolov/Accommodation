namespace Accommodation.Application.Accommodations.Commands
{
    using FluentValidation;

    public class CreateAccommodationCommandValidator : AbstractValidator<CreateAccommodationCommand>
    {
        public CreateAccommodationCommandValidator()
        {
            RuleFor(v => v.Name)
                .MinimumLength(3)
                .MaximumLength(25)
                .NotEmpty();

            RuleFor(v => v.Desccription)
                .MaximumLength(200);
        }
    }
}
