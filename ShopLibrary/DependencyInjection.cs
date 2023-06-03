using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopDAL.EF;
using ShopDAL.Scenarios.Interfaces;

namespace ShopDAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, string connectionString)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException($"\"{nameof(connectionString)}\" не может быть неопределенным или пустым.", nameof(connectionString));
            }

            services.AddDbContext<ShopContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IShopContext>(provider =>
                provider.GetService<ShopContext>());

            return services;
        }
    }
}
