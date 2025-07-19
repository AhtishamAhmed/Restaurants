using Microsoft.EntityFrameworkCore;
using Restaurants.Application.Interfaces;
using Restaurants.Domain.Entities;
using Restaurants.Persistance.Context;
namespace Restaurants.Persistance.Repositories
{
    public class RestaurantsRepository : IRestaurantsRepository
    {
        private readonly RestaurantDbContext _dbContext;

        public RestaurantsRepository(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Create(Restaurant entity)
        {
            _dbContext.Restaurants.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }
    }
}
