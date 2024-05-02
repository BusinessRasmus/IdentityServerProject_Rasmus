using System.Security.AccessControl;
using IdentityServerProject_Rasmus.Shared.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;

namespace IdentityServerProject_Rasmus.DataAccess.Database;

public class MongoDbContext
{
    
    private readonly IMongoDatabase _mongoDatabase;
    public MongoDbContext()
    {

        var client = new MongoClient("mongodb://localhost:27017"); //TODO Put in connection string
        _mongoDatabase = client.GetDatabase("TestDb");

    }

    public IMongoCollection<ShopProduct> BaseProducts => _mongoDatabase.GetCollection<ShopProduct>("ShopProducts");

    public IMongoCollection<ProductCategory> ProductCategories => _mongoDatabase.GetCollection<ProductCategory>("ProductCategories");

}