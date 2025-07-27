using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Exceptions;
using Restaurants.Application.Features.Restaurants.DTOs;
using Restaurants.Application.Interfaces;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;
using Restaurants.Application.Wrappers;

namespace Restaurants.Application.Features.Restaurants.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQueryHandler : IRequestHandler<GetRestaurantByIdQuery, ApiResponse<RestaurantDto>>
    {
        private readonly ILogger<GetRestaurantByIdQueryHandler> _logger;
        private readonly IRestaurantsRepository _restaurantsRepository;

        public GetRestaurantByIdQueryHandler(
            ILogger<GetRestaurantByIdQueryHandler> logger,
            IRestaurantsRepository restaurantsRepository)
        {
            _logger = logger;
            _restaurantsRepository = restaurantsRepository;
        }

        public async Task<ApiResponse<RestaurantDto>> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting restaurant {RestaurantId}", request.Id);
            var restaurant = await _restaurantsRepository.GetByIdAsync(request.Id)
                ?? throw new ApiException("Not Found");

            return new ApiResponse<RestaurantDto>(restaurant, "Get Restaurant");
        }
    }
}
