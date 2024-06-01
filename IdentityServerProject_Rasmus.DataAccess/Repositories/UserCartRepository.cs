using Amazon.Runtime;
using IdentityServerProject_Rasmus.DataAccess.Database;
using IdentityServerProject_Rasmus.Shared.Entities;
using IdentityServerProject_Rasmus.Shared.Interfaces;
using MongoDB.Driver;

namespace IdentityServerProject_Rasmus.DataAccess.Repositories;

public class UserCartRepository(MongoDbContext mongoDbContext) : IService<UserCart, string>
{

    private readonly MongoDbContext _mongoDbContext = mongoDbContext;


    public async Task<IEnumerable<UserCart>> GetAllAsync()
    {
        var filter = Builders<UserCart>.Filter.Empty;

        return await _mongoDbContext.Carts.Find(filter).ToListAsync();
    }

    public async Task<UserCart> GetByIdAsync(string id)
    {
        var filter = Builders<UserCart>.Filter.Eq(x => x.UserEmail, id);

        return await _mongoDbContext.Carts.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<bool> CreateAsync(UserCart entity)
    {
        await _mongoDbContext.Carts.InsertOneAsync(entity);

        return true;
    }

    public async Task<UserCart> UpdateAsync(UserCart entity)
    {
        var filter = Builders<UserCart>.Filter.Eq(x => x.Id, entity.Id);

        var update = Builders<UserCart>.Update
            .Set(d => d.ShopProducts, entity.ShopProducts);

        await _mongoDbContext.Carts.UpdateOneAsync(filter, update);

        return await GetByIdAsync(entity.UserEmail);
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        var filter = Builders<UserCart>.Filter.Eq(x => x.Id, id);

        await _mongoDbContext.Carts.DeleteOneAsync(filter);

        return true;
    }
}