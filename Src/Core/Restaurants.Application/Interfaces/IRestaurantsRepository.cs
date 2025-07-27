using Microsoft.EntityFrameworkCore;
using Restaurants.Application.Features.Restaurants.DTOs;
using Restaurants.Domain.Entities;
namespace Restaurants.Application.Interfaces
{
    public interface IRestaurantsRepository
    {
        Task<Guid> Create(Restaurant entity);
        Task<RestaurantDto> GetByIdAsync(Guid id);
        Task Delete(RestaurantDto entity);
        Task<IEnumerable<RestaurantDto>> GetRestaurantsAsync();
    }
}
