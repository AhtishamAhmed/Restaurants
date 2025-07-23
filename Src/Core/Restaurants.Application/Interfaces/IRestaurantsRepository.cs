using Restaurants.Domain.Entities;
namespace Restaurants.Application.Interfaces
{
    public interface IRestaurantsRepository
    {
        Task<Guid> Create(Restaurant entity);
        Task<Restaurant?> GetByIdAsync(Guid id);
        Task Delete(Restaurant entity);
    }
}
