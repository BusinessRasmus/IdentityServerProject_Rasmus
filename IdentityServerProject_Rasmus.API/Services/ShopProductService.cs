using IdentityServerProject_Rasmus.Shared.DTOs;
using IdentityServerProject_Rasmus.Shared.Interfaces;

namespace IdentityServerProject_Rasmus.API.Services;

public class ShopProductService : IService<ShopProductDto>
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

    public Task<ShopProductDto> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ShopProductDto> CreateAsync(ShopProductDto entity)
    {
        throw new NotImplementedException();
    }

    public Task<ShopProductDto> UpdateAsync(ShopProductDto entity)
    {
        throw new NotImplementedException();
    }

    public Task<ShopProductDto> DeleteByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}