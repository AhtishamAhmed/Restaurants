using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Interfaces
{
    public interface IRestaurantDbContext
    {
        DbSet<Restaurant> Restaurants { get; set; }
        DbSet<Dish> Dishes { get; set; }

        Task<int> SaveChangesAsync();
    }
}
