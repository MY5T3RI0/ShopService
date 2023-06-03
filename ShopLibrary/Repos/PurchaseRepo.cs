using Microsoft.EntityFrameworkCore;
using ShopDAL.Models;
using ShopDAL.Repos.Interfaces;
using ShopDAL.Scenarios.Interfaces;

namespace ShopDAL.Repos
{
    public class PurchaseRepo<T> : BaseRepo<Purchase>, IPurchaseRepo
    {
        public List<Purchase> GetRelatedData() => Context.Purchases.FromSql($"SELECT * FROM Purchase")
            .Include(x => x.Customer)
            .Include(x => x.StoreProducts).ThenInclude(x => x.PurchaseDetails).ThenInclude(x => x.Product)
            .Include(x => x.StoreProducts).ThenInclude(x => x.Store)
            .ToList();

        public async Task<List<Purchase>> GetRelatedDataAsync() => await Context.Purchases.FromSql($"SELECT * FROM Purchase")
            .Include(x => x.Customer)
            .Include(x => x.StoreProducts).ThenInclude(x => x.PurchaseDetails).ThenInclude(x => x.Product)
            .Include(x => x.StoreProducts).ThenInclude(x => x.Store)
            .ToListAsync();

        public async Task<Purchase> GetRelatedDataAsync(int id) => await Context.Purchases.FromSql($"SELECT * FROM Purchase")
            .Include(x => x.Customer)
            .Include(x => x.StoreProducts).ThenInclude(x => x.PurchaseDetails).ThenInclude(x => x.Product)
            .Include(x => x.StoreProducts).ThenInclude(x => x.Store)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}