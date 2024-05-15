using IdentityServerProject_Rasmus.Shared.DTOs;
using IdentityServerProject_Rasmus.Shared.Interfaces;

namespace IdentityServerProject_Rasmus.API.Services;

public class UserCartService : IService<UserCartDto>
{
    private readonly HttpClient _httpClient;

    public UserCartService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("IdentityServerMongoDbAPI");
    }

    public async Task<IEnumerable<UserCartDto>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync("api/carts");
        var result = await response.Content.ReadFromJsonAsync<List<UserCartDto>>();

        return result;
    }

    public async Task<UserCartDto> GetByIdAsync(Guid id)
    {
        var response = await _httpClient.GetAsync($"api/carts/{id}");
        var result = await response.Content.ReadFromJsonAsync<UserCartDto>();

        return result;
    }

    public async Task<bool> CreateAsync(UserCartDto entity)
    {
        var response = await _httpClient.PostAsJsonAsync("api/carts", entity);
        var result = await response.Content.ReadFromJsonAsync<bool>();

        return result;
    }

    public async Task<UserCartDto> UpdateAsync(UserCartDto entity)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/carts/{entity.UserId}", entity);
        var result = await response.Content.ReadFromJsonAsync<UserCartDto>();

        return result;
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"api/carts/{id}");
        var result = await response.Content.ReadFromJsonAsync<bool>();

        return result;
    }
}