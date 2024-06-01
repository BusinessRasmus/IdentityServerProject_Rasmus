using IdentityServerProject_Rasmus.Shared.DTOs;
using IdentityServerProject_Rasmus.Shared.Entities;
using IdentityServerProject_Rasmus.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServerProject_Rasmus.API.Extensions;

public static class ShopProductEndpoints
{

    public static IEndpointRouteBuilder MapShopProductEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/shopproducts");

        group.MapGet("/", GetAllAsync);
        group.MapGet("/{id}", GetByIdAsync);
        group.MapPut("/{id}", UpdateAsync);
        group.MapPost("/", CreateAsync);
        group.MapDelete("/{id}", DeleteByIdAsync);


        return app;

    }

    public static async Task<IEnumerable<ShopProduct>> GetAllAsync([FromServices]IService<ShopProduct, Guid> repository)
    {
        
        var allProducts = await repository.GetAllAsync();
        return allProducts;
    }

    public static async Task<ShopProduct> GetByIdAsync(IService<ShopProduct, Guid> repository, Guid id)
    {
        var product = await repository.GetByIdAsync(id);
        return product;
    }

    public static async Task<bool> CreateAsync(IService<ShopProduct, Guid> repository, ShopProduct entity)
    {
        var newProduct = new ShopProduct
        {
            Name = entity.Name,
            Description = entity.Description,
            Price = entity.Price,
            ImageUrl = entity.ImageUrl
        };

        return await repository.CreateAsync(newProduct);

    }

    public static async Task<ShopProduct> UpdateAsync(IService<ShopProduct, Guid> repository, ShopProduct entity)
    {
        return await repository.UpdateAsync(entity);
    }

    public static async Task<bool> DeleteByIdAsync(IService<ShopProduct, Guid> repository, Guid id)
    {
        return await repository.DeleteByIdAsync(id);
    }
}