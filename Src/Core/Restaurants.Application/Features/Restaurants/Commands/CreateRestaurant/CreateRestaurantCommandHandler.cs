using AutoMapper;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Interfaces;
using Restaurants.Application.Wrappers;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Features.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, ApiResponse<Guid>>
    {
        private readonly ILogger<CreateRestaurantCommandHandler> _logger;
        private readonly IRestaurantsRepository _restaurantsRepository;

        public CreateRestaurantCommandHandler(
            ILogger<CreateRestaurantCommandHandler> logger,
            IRestaurantsRepository restaurantsRepository)
        {
            _logger = logger;
            _restaurantsRepository = restaurantsRepository;
        }

        public async Task<ApiResponse<Guid>> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("create reataurant");

            var restaurant = request.Adapt<Restaurant>(); 

            var result = await _restaurantsRepository.Create(restaurant);

            return new ApiResponse<Guid>(result, "Create Restaurant Successfully");
        }
    }
}