namespace Accommodation.Application.Locations.Commands
{
    using FluentValidation;

    public class CreateLocationValidator : AbstractValidator<CreateLocationCommand>
    {
        public CreateLocationValidator()
        {
            RuleFor(v => v.Latitude)
                .GreaterThanOrEqualTo(-90)
                .LessThanOrEqualTo(90);

            RuleFor(v => v.Longitude)
                    .GreaterThanOrEqualTo(-180)
                    .LessThanOrEqualTo(180);
        }
    }
}
