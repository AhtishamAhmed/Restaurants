using AutoMapper;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Interfaces;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Features.Restaurants.Commands
{
    public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, Guid>
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

        public async Task<Guid> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("create reataurant");

            var restaurant = request.Adapt<Restaurant>(); 

            var result = await _restaurantsRepository.Create(restaurant);

            return result;
        }
    }
}