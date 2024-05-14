using System;
using System.Runtime.InteropServices.ComTypes;
using IdentityServerProject_Rasmus.DataAccess.Database;
using IdentityServerProject_Rasmus.Shared.Entities;
using IdentityServerProject_Rasmus.Shared.Interfaces;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace IdentityServerProject_Rasmus.DataAccess.Repositories;

public class ShopProductRepository(MongoDbContext mongoDbContext) : IService<ShopProduct>
{
    private readonly MongoDbContext _mongoDbContext = mongoDbContext;


    public async Task<IEnumerable<ShopProduct>> GetAllAsync()
    {
        var filter = Builders<ShopProduct>.Filter.Empty;

        return await _mongoDbContext.ShopProducts.Find(filter).ToListAsync();
    }
    

    public async Task<ShopProduct> GetByIdAsync(Guid id)
    {
        var filter = Builders<ShopProduct>.Filter.Eq(x => x.Id, id);

        return await _mongoDbContext.ShopProducts.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<bool> CreateAsync(ShopProduct entity)
    {
        await _mongoDbContext.ShopProducts.InsertOneAsync(entity);

        //TODO Implement guard clauses

        return true;
    }

    public async Task<ShopProduct> UpdateAsync(ShopProduct entity)
    {
        var filter = Builders<ShopProduct>.Filter.Eq(x => x.Id, entity.Id);

        var update = Builders<ShopProduct>.Update
            .Set(d => d, entity);

        await _mongoDbContext.ShopProducts.UpdateOneAsync(filter, update);

        return await GetByIdAsync(entity.Id);
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        var filter = Builders<ShopProduct>.Filter.Eq(x => x.Id, id);

        await _mongoDbContext.ShopProducts.DeleteOneAsync(filter);

        return true;

    }
}