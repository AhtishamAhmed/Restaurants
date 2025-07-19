using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Interfaces;
using Restaurants.Persistance.Context;
using Restaurants.Persistance.Repositories;

namespace Restaurants.Persistance
{
    public static class ServiceExtentions
    {
        public static void AddPersistance(this IServiceCollection services, IConfiguration configuaration)
        {
            services.AddDbContext<RestaurantDbContext>
                (opt => opt.UseSqlServer(configuaration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IRestaurantDbContext, RestaurantDbContext>();
            services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
            
        }
    }
}
