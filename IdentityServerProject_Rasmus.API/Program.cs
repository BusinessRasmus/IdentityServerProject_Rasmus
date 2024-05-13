using IdentityServerProject_Rasmus.DataAccess.Database;
using IdentityServerProject_Rasmus.DataAccess.Repositories;
using IdentityServerProject_Rasmus.Shared.DTOs;
using IdentityServerProject_Rasmus.Shared.Entities;
using IdentityServerProject_Rasmus.Shared.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<MongoDbContext>();
builder.Services.AddScoped<IService<ShopProduct>, ShopProductRepository>();


var app = builder.Build();


app.Run();
