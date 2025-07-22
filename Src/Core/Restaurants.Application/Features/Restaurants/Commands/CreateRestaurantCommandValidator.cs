using FluentValidation;
namespace Restaurants.Application.Features.Restaurants.Commands
{
    public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
    {
        public CreateRestaurantCommandValidator()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty()
                .NotNull()
                .Length(3, 100);

            RuleFor(dto => dto.Category)
                .NotNull()
                .NotEmpty()
            .WithMessage("Please choose from the valid categories.");

            RuleFor(dto => dto.ContactEmail)
                .EmailAddress()
                .WithMessage("Please provide a valid email address");
        }
    }
}
