using Microsoft.EntityFrameworkCore;
using Restaurants.Application.Features.Restaurants.DTOs;
using Restaurants.Application.Interfaces;
using Restaurants.Domain.Entities;
using Restaurants.Persistance.Context;
using System.Collections.Immutable;
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
        public async Task<RestaurantDto> GetByIdAsync(Guid id)
        {
            var restaurantDtos =await _dbContext.Restaurants
                .Where(r => r.Id == id) 
                .Select
                (r => new RestaurantDto
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Category = r.Category,
                HasDelivery = r.HasDelivery,
                Dishes = r.Dishes.Select(d => new DishDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Price = d.Price
                }).ToList()
                }).FirstOrDefaultAsync();


            return restaurantDtos!;
        }
        public async Task Delete(RestaurantDto entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<RestaurantDto>> GetRestaurantsAsync()
        {
            var restaurants = await _dbContext.Restaurants
            .Include(r => r.Dishes)
            .ToListAsync();

            var restaurantDtos = restaurants.Select(r => new RestaurantDto
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Category = r.Category,
                HasDelivery = r.HasDelivery,
                Dishes = r.Dishes.Select(d => new DishDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Price = d.Price
                }).ToList()
            });
            return restaurantDtos;
        }
    }
}
