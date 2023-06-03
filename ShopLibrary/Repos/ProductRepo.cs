using Microsoft.EntityFrameworkCore;
using ShopDAL.Models;
using ShopDAL.Repos.Interfaces;
using ShopDAL.Scenarios.Interfaces;

namespace ShopDAL.Repos
{
    public class ProductRepo<T> : BaseRepo<Product>, IProductRepo
    {
        public List<Product> GetRelatedData() => Context.Products.FromSql($"SELECT * FROM Product")
            .Include(x => x.Manufacturer)
            .Include(x => x.Category)
            .ToList();

        public async Task<List<Product>> GetRelatedDataAsync() => await Context.Products.FromSql($"SELECT * FROM Product")
            .Include(x => x.Manufacturer)
            .Include(x => x.Category)
            .Include(x => x.PriceChanges).ThenInclude(y => y.ChangesDetails)
            .ToListAsync();

        public async Task<Product> GetRelatedDataAsync(int id) => await Context.Products.FromSql($"SELECT * FROM Product")
            .Include(x => x.Manufacturer)
            .Include(x => x.Category)
            .Include(x => x.PriceChanges).ThenInclude(x => x.ChangesDetails.Where(x => x.ProductId == id))
            .FirstOrDefaultAsync(x => x.Id == id);



    }
}