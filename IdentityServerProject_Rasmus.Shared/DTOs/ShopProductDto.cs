using IdentityServerProject_Rasmus.Shared.Entities;

namespace IdentityServerProject_Rasmus.Shared.DTOs;

public class ShopProductDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public string ImageUrl { get; set; }

    public ProductCategoryDto Category { get; set; }
}