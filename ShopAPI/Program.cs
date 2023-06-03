using ShopAPI.Services;
using ShopDAL;
using ShopDAL.Models;
using ShopDAL.Repos;
using ShopDAL.Repos.Interfaces;
using ShopDAL.Scenarios;
using ShopDAL.Scenarios.Common.Mappings;
using ShopDAL.Scenarios.Interfaces;
using System.Reflection;

public class Program
{
    private static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            config.AddProfile(new AssemblyMappingProfile(typeof(IShopContext).Assembly));
        });

        builder.Services.AddTransient<IRepo<Product>, ProductRepo<Product>>();
        builder.Services.AddTransient<IRepoService<Product>, RepoService<Product>>();
        builder.Services.AddTransient<IRepo<Delivery>, DeliveryRepo<Delivery>>();
        builder.Services.AddTransient<IRepoService<Delivery>, RepoService<Delivery>>();
        builder.Services.AddTransient<IRepo<Category>, BaseRepo<Category>>();
        builder.Services.AddTransient<IRepoService<Category>, RepoService<Category>>();
        builder.Services.AddTransient<IRepo<Customer>, BaseRepo<Customer>>();
        builder.Services.AddTransient<IRepoService<Customer>, RepoService<Customer>>();
        builder.Services.AddTransient<IRepo<Manufacturer>, BaseRepo<Manufacturer>>();
        builder.Services.AddTransient<IRepoService<Manufacturer>, RepoService<Manufacturer>>();
        builder.Services.AddTransient<IRepo<PriceChange>, PriceChangeRepo<PriceChange>>();
        builder.Services.AddTransient<IRepoService<PriceChange>, RepoService<PriceChange>>();
        builder.Services.AddTransient<IRepo<Purchase>, PurchaseRepo<Purchase>>();
        builder.Services.AddTransient<IRepoService<Purchase>, RepoService<Purchase>>();
        builder.Services.AddTransient<IRepo<Store>, StoreRepo<Store>>();
        builder.Services.AddTransient<IRepoService<Store>, RepoService<Store>>();

        builder.Services.AddApplication();
        builder.Configuration.AddJsonFile("appsettings.json");
        var connectionStr = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddPersistence(connectionStr);
        builder.Services.AddControllers();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
        });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseCors("AllowAll");

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}