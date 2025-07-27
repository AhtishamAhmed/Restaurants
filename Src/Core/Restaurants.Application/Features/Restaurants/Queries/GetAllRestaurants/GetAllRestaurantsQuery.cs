using MediatR;
using Restaurants.Application.Features.Restaurants.DTOs;
using Restaurants.Application.Wrappers;
namespace Restaurants.Application.Features.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantsQuery : IRequest<ApiResponse<IEnumerable<RestaurantDto>>>
{
 
}
