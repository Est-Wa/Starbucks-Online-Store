using Microsoft.EntityFrameworkCore;
using Repository;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUsersRepositories, UsersRepositories>();
builder.Services.AddDbContext<StoreDbContext>(options => options.UseSqlServer("Data Sourece = srv2\\pupils ; Initial Catalog = StoreDB ; Integrated Security = True; Pooling = False"));



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();

app.Run();
