using Microsoft.EntityFrameworkCore;
using ShopDAL.Models;
using ShopDAL.Repos.Interfaces;
using ShopDAL.Scenarios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDAL.Repos
{
    public class StoreRepo<T> : BaseRepo<Store>, IStoreRepo
    {
        public List<Store> GetRelatedData() => Context.Stores.FromSqlRaw("SELECT * FROM Store")
            .Include(x => x.ProductsInStore).ThenInclude(x => x.Product)
            .Include(x => x.Purchases).ThenInclude(x => x.Customer)
            .Include(x => x.Deliveries).ToList();

        public async Task<List<Store>> GetRelatedDataAsync() => await Context.Stores.FromSqlRaw("SELECT * FROM Store")
            .Include(x => x.ProductsInStore).ThenInclude(x => x.Product)
            .Include(x => x.Purchases).ThenInclude(x => x.Customer)
            .Include(x => x.Deliveries).ToListAsync();

        public async Task<Store> GetRelatedDataAsync(int id) => await Context.Stores.FromSqlRaw("SELECT * FROM Store")
            .Include(x => x.ProductsInStore).ThenInclude(x => x.Product)
            .Include(x => x.Purchases).ThenInclude(x => x.Customer)
            .Include(x => x.Deliveries)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}
