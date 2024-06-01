using IdentityServerProject_Rasmus.API.Extensions;
using IdentityServerProject_Rasmus.DataAccess.Database;
using IdentityServerProject_Rasmus.DataAccess.Repositories;
using IdentityServerProject_Rasmus.Shared.DTOs;
using IdentityServerProject_Rasmus.Shared.Entities;
using IdentityServerProject_Rasmus.Shared.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<MongoDbContext>();
builder.Services.AddScoped<IService<ShopProduct, Guid>, ShopProductRepository>();
builder.Services.AddScoped<IService<UserCart, string>, UserCartRepository>();


var app = builder.Build();


app.MapShopProductEndpoints();
app.MapUserCartEndpoints();

app.Run();
