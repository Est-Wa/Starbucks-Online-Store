using Microsoft.EntityFrameworkCore;
using Repository;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUsersRepositories, UsersRepositories>();
builder.Services.AddDbContext<StoreDbContext>(options => options.UseSqlServer("Data Sourece = srv2\\pupils ; Initial Catalog = StoreDB ; Integrated Security = True; Pooling = False"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();

app.Run();
