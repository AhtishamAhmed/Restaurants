using Mapster;
using Restaurants.Application.Features.Restaurants.Commands;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Mappings
{
    public class RestaurantMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateRestaurantCommand, Restaurant>()
                .Map(dest => dest.Address, src => new Address
                {
                    City = src.City,
                    Street = src.Street,
                    PostalCode = src.PostalCode
                });
        }
    }
}
