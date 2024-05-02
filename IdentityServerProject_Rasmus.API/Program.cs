using IdentityServerProject_Rasmus.DataAccess.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<MongoDbContext>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
