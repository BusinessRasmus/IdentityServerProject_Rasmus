using IdentityServerProject_Rasmus.Shared.DTOs;
using IdentityServerProject_Rasmus.Shared.Interfaces;

namespace IdentityServerProject_Rasmus.API.Services;

public class ShopProductService : IService<ShopProductDto, Guid>
{
    
    private readonly HttpClient _httpClient;

    public ShopProductService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("IdentityServerMongoDbAPI");
    }

    public async Task<IEnumerable<ShopProductDto>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync("api/shopproducts");
        var result = await response.Content.ReadFromJsonAsync<List<ShopProductDto>>();

        return result;
    }

    public async Task<ShopProductDto> GetByIdAsync(Guid id)
    {
        var response = await _httpClient.GetAsync($"api/shopproducts/{id}");
        var result = await response.Content.ReadFromJsonAsync<ShopProductDto>();

        return result;
    }

    public async Task<bool> CreateAsync(ShopProductDto entity)
    {
        var response = await _httpClient.PostAsJsonAsync("api/shopproducts", entity);
        var result = await response.Content.ReadFromJsonAsync<bool>();

        return result;
    }

    public async Task<ShopProductDto> UpdateAsync(ShopProductDto entity)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/shopproducts/{entity.Id}", entity);
        var result = await response.Content.ReadFromJsonAsync<ShopProductDto>();

        return result;
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"api/shopproducts/{id}");
        var result = await response.Content.ReadFromJsonAsync<bool>();

        return result;
    }
}