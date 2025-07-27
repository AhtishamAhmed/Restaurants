using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Features.Restaurants.DTOs;
using Restaurants.Application.Interfaces;
using Restaurants.Application.Wrappers;

namespace Restaurants.Application.Features.Restaurants.Queries.GetAllRestaurants;


public class GetAllRestaurantsQueryHandler : IRequestHandler<GetAllRestaurantsQuery, ApiResponse<IEnumerable<RestaurantDto>>>
{
    private readonly IRestaurantsRepository _restaurantsRepository;
    private readonly ILogger<GetAllRestaurantsQueryHandler> _logger;

    public GetAllRestaurantsQueryHandler(IRestaurantsRepository restaurantsRepository,
        ILogger<GetAllRestaurantsQueryHandler> logger)
    {
        _restaurantsRepository = restaurantsRepository;
        _logger = logger;
    }
    public async Task<ApiResponse<IEnumerable<RestaurantDto>>> Handle(GetAllRestaurantsQuery getAllRestaurantsQuery, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting all restaurants");
        var result = await _restaurantsRepository.GetRestaurantsAsync();

        return new ApiResponse<IEnumerable<RestaurantDto>>(result, "Get All Restaurants");
    }

}
