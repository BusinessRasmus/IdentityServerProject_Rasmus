using IdentityServerProject_Rasmus.DataAccess.Database;
using IdentityServerProject_Rasmus.Shared.Entities;
using IdentityServerProject_Rasmus.Shared.Interfaces;
using MongoDB.Driver;

namespace IdentityServerProject_Rasmus.DataAccess.Repositories;

public class ShopProductRepository(MongoDbContext mongoDbContext) : IService<ShopProduct>
{
    private readonly MongoDbContext _mongoDbContext = mongoDbContext;


    public async Task<IEnumerable<ShopProduct>> GetAllAsync()
    {
        var filter = Builders<ShopProduct>.Filter.Empty;

        return await _mongoDbContext.BaseProducts.Find(filter).ToListAsync();
    }
    

    public async Task<ShopProduct> GetByIdAsync(Guid id)
    {
        var filter = Builders<ShopProduct>.Filter.Eq(x => x.Id, id);

        return await _mongoDbContext.BaseProducts.Find(filter).FirstOrDefaultAsync();
    }

    public Task<ShopProduct> CreateAsync(ShopProduct entity)
    {
        throw new NotImplementedException(); //TODO Implement methods
    }

    public Task<ShopProduct> UpdateAsync(ShopProduct entity)
    {
        throw new NotImplementedException();
    }

    public Task<ShopProduct> DeleteByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}