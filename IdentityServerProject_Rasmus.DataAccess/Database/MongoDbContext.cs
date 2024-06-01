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

        var client = new MongoClient("mongodb://localhost:27017");
        _mongoDatabase = client.GetDatabase("IdentityTestDB");

    }

    public IMongoCollection<ShopProduct> ShopProducts => _mongoDatabase.GetCollection<ShopProduct>("ShopProducts");

    public IMongoCollection<UserCart> Carts => _mongoDatabase.GetCollection<UserCart>("Carts");

}