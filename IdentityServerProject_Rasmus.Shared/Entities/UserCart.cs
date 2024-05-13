namespace IdentityServerProject_Rasmus.Shared.Entities;

public class UserCart
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public List<ShopProduct> ShopProducts { get; set; }
}