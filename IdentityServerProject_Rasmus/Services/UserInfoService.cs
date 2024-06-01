using IdentityServerProject_Rasmus.Shared.DTOs;
using Microsoft.AspNetCore.Components.Authorization;

namespace IdentityServerProject_Rasmus.API.Services;

public class UserInfoService(AuthenticationStateProvider authState)
{

    public UserCartDto? UserCart { get; set; }

    public async Task<string> GetLoggedInUserEmail()
    {
        var authStateAsync = await authState.GetAuthenticationStateAsync();
        var user = authStateAsync.User;
        var loggedInUserEmail = string.Empty;

        if (user.Identity.IsAuthenticated)
        {
            loggedInUserEmail = user.Identity.Name;
        }

        return loggedInUserEmail;
    }

    

}