namespace IdentityServerProject_Rasmus.Shared.Entities;

public class ShopProduct
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public string ImageUrl { get; set; }

    public ProductCategory Category { get; set; }
}