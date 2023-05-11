using DTO;
using Microsoft.EntityFrameworkCore;
using OurWebsite;
using Repository;
using Services;
using NLog.Web;
using Microsoft.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUsersRepositories, UsersRepositories>();

builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();

builder.Services.AddAutoMapper(typeof(AutoMapping));//type of what?????????????
//builder.Services.AddTransient<IPasswordService, PasswordService>();

public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
    .UseStartup<Startup>()
    .UseNLog();




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
