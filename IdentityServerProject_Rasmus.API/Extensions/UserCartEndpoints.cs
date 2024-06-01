using IdentityServerProject_Rasmus.Shared.Entities;
using IdentityServerProject_Rasmus.Shared.Interfaces;

namespace IdentityServerProject_Rasmus.API.Extensions;

public static class UserCartEndpoints
{
    public static IEndpointRouteBuilder MapUserCartEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/carts");

        group.MapGet("/", GetAllAsync);
        group.MapGet("/{id}", GetByUserIdAsync);
        group.MapPut("/{id}", UpdateAsync);
        group.MapPost("/", CreateAsync);
        group.MapDelete("/{id}", DeleteByIdAsync);

        return app;
    }

    private static async Task<IEnumerable<UserCart>> GetAllAsync(IService<UserCart, string> repository)
    {
        var allCarts = await repository.GetAllAsync();

        return allCarts;
    }

    private static async Task<UserCart> GetByUserIdAsync(IService<UserCart, string> repository, string id)
    {
        var cart = await repository.GetByIdAsync(id);

        return cart;
    }

    private static async Task<bool> CreateAsync(IService<UserCart, string> repository, UserCart entity)
    {
        return await repository.CreateAsync(entity);
    }

    private static async Task<UserCart> UpdateAsync(IService<UserCart, string> repository, UserCart entity)
    {
        var cartToUpdate = await repository.GetByIdAsync(entity.UserEmail);

        var updatedCart = await repository.UpdateAsync(cartToUpdate);

        return updatedCart;
    }

    private static async Task<bool> DeleteByIdAsync(IService<UserCart, string> repository, Guid id)
    {
        return await repository.DeleteByIdAsync(id);
    }
}