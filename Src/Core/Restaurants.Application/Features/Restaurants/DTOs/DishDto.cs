namespace Restaurants.Application.Features.Restaurants.DTOs
{ 
    public class DishDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}