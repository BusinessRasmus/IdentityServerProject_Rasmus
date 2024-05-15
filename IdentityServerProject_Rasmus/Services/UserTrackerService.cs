using IdentityServerProject_Rasmus.Shared.DTOs;

namespace IdentityServerProject_Rasmus.Services;

public class UserTrackerService
{
    public string? CurrentUserEmail { get; set; }

    public void SetCurrentUserEmail(string? email)
    {
        CurrentUserEmail = email;
    }

    public List<ShopProductDto>? UserCart { get; set; }
}