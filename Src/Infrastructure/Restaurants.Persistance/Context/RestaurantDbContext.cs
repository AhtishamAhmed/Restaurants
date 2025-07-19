using Microsoft.EntityFrameworkCore;
using Restaurants.Application.Interfaces;
using Restaurants.Domain.Entities;

namespace Restaurants.Persistance.Context
{
    public class RestaurantDbContext : DbContext, IRestaurantDbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {
        }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Restaurant>()
                .OwnsOne(r => r.Address);

            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.Dishes)
                .WithOne()
                .HasForeignKey(d => d.RestaurantId);
        }
    }
}
