using IdentityServerProject_Rasmus.Shared.Entities;


namespace IdentityServerProject_Rasmus.Shared.DTOs;

public class UserCartDto
{
    public Guid Id { get; set; }
   
    public Guid UserId { get; set; }
  
    public List<ShopProductDto> ShopProducts { get; set; }
}