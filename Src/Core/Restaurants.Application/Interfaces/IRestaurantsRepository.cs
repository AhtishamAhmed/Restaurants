using Restaurants.Domain.Entities;
namespace Restaurants.Application.Interfaces
{
    public interface IRestaurantsRepository
    {
        Task<Guid> Create(Restaurant entity);
    }
}
