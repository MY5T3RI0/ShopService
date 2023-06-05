using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using ShopAPI;
using ShopAPI.Middleware;
using ShopAPI.Services;
using ShopDAL;
using ShopDAL.Models;
using ShopDAL.Repos;
using ShopDAL.Repos.Interfaces;
using ShopDAL.Scenarios;
using ShopDAL.Scenarios.Common.Mappings;
using ShopDAL.Scenarios.Interfaces;
using Swashbuckle.AspNetCore.SwaggerGen;
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

        builder.Services.AddAuthentication(config =>
        {
            config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer("Bearer", options =>
            {
                options.Authority = "http://localhost:44300/";
                options.Audience = "ShopAPI";
                options.RequireHttpsMetadata = false;
            });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddVersionedApiExplorer(options =>
            options.GroupNameFormat = "'v'VVV");
        builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>,
            ConfigureSwaggerOptions>();
        builder.Services.AddSwaggerGen(config =>
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            config.IncludeXmlComments(xmlPath);
        });

        builder.Services.AddApiVersioning();

        var app = builder.Build();
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    config.SwaggerEndpoint(
                    $"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant());
                }
            });
        }

        app.UseCustomExceptionHandler();
        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseCors("AllowAll");
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseApiVersioning();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}