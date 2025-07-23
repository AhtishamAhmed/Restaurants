using MediatR;
using Restaurants.Application.Wrappers;

namespace Restaurants.Application.Features.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommand: IRequest<ApiResponse<object?>>
    {
        public Guid Id { get; set; }
    }
}


