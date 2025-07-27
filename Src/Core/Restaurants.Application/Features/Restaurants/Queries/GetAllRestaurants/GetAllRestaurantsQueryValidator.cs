using FluentValidation;

namespace Restaurants.Application.Features.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantsQueryValidator : AbstractValidator<GetAllRestaurantsQuery>
{
    public GetAllRestaurantsQueryValidator()
    {
    }
}
