namespace Accommodation.Application.Accommodations.Commands.CreateHotel
{
    using FluentValidation;

    public class CreateHotelCommandValidator : AbstractValidator<CreateHotelCommand>
    {
        public CreateHotelCommandValidator()
        {
            RuleFor(v => v.Name)
                .MinimumLength(3)
                .MaximumLength(25)
                .NotEmpty();

            RuleFor(v => v.Desccription)
                .MaximumLength(200);

            RuleFor(v => v.Email)
                .EmailAddress();
        }
    }
}
