using MediatR;
using Restaurants.Application.Features.Restaurants.DTOs;
using Restaurants.Application.Wrappers;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById;

public class GetRestaurantByIdQuery: IRequest<ApiResponse<RestaurantDto>>
{
    public Guid Id { get; set; } 
}
