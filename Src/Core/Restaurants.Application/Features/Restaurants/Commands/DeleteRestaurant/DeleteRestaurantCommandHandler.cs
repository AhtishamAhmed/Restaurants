using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Exceptions;
using Restaurants.Application.Interfaces;
using Restaurants.Application.Wrappers;
using Restaurants.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Restaurants.Application.Features.Restaurants.Commands.DeleteRestaurant
{

    public class DeleteRestaurantCommandHandler: IRequestHandler<DeleteRestaurantCommand, ApiResponse<object?>>
    {
        private readonly IRestaurantsRepository _restaurantsRepository;
        private readonly ILogger<DeleteRestaurantCommandHandler> _logger;

        public DeleteRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository, ILogger<DeleteRestaurantCommandHandler> logger)
        {
            _restaurantsRepository = restaurantsRepository;
            _logger = logger;
        }
        public async Task<ApiResponse<object?>> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Deleting restaurant with id: {RestaurantId}", request.Id);
            var restaurant = await _restaurantsRepository.GetByIdAsync(request.Id);
            if (restaurant is null)
                throw new ApiException("Restaurant is not found");

            await _restaurantsRepository.Delete(restaurant);
            return new ApiResponse<object?>(null, "Restaurant Delete Successfully");
        }

    }

}