using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Mappings;
using System.Reflection;
namespace Restaurants.Application
{
    public static class ServiceExtentions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMapster(); 
            TypeAdapterConfig.GlobalSettings.Scan(typeof(RestaurantMappingConfig).Assembly);
            services.AddMediatR(conf => conf.RegisterServicesFromAssembly
                               (Assembly.GetExecutingAssembly()));


        }
    }
}
