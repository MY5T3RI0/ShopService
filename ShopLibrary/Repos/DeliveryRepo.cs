using Microsoft.EntityFrameworkCore;
using ShopDAL.Models;
using ShopDAL.Repos.Interfaces;
using ShopDAL.Scenarios.Interfaces;

namespace ShopDAL.Repos
{
    public class DeliveryRepo<T> : BaseRepo<Delivery>, IDeliveryRepo
    {
        public List<Delivery> GetRelatedData() => Context.Deliveries.FromSql($"SELECT * FROM Delivery")
            .Include(x => x.DeliveryInfos).ThenInclude(x => x.Product).ThenInclude(x => x.Manufacturer)
            .Include(x => x.DeliveryInfos).ThenInclude(x => x.Product).ThenInclude(x => x.Category)
            .Include(x => x.DeliveryInfos).ThenInclude(x => x.Product).ThenInclude(x => x.PriceChanges)
            .Include(x => x.DeliveryInfos).ThenInclude(x => x.Product).ThenInclude(x => x.ChangesDetails)
            .Include(x => x.Store).ThenInclude(x => x.ProductsInStore).ThenInclude(x => x.Product)
            .ToList();

        public async Task<List<Delivery>> GetRelatedDataAsync() => await Context.Deliveries.FromSql($"SELECT * FROM Delivery")
            .Include(x => x.DeliveryInfos).ThenInclude(x => x.Product).ThenInclude(x => x.Manufacturer)
            .Include(x => x.DeliveryInfos).ThenInclude(x => x.Product).ThenInclude(x => x.Category)
            .Include(x => x.DeliveryInfos).ThenInclude(x => x.Product).ThenInclude(x => x.PriceChanges)
            .Include(x => x.DeliveryInfos).ThenInclude(x => x.Product).ThenInclude(x => x.ChangesDetails)
            .Include(x => x.Store)
            .ToListAsync();

        public async Task<Delivery> GetRelatedDataAsync(int id) => await Context.Deliveries.FromSql($"SELECT * FROM Delivery")
            .Include(x => x.DeliveryInfos).ThenInclude(x => x.Product).ThenInclude(x => x.Manufacturer)
            .Include(x => x.DeliveryInfos).ThenInclude(x => x.Product).ThenInclude(x => x.Category)
            .Include(x => x.DeliveryInfos).ThenInclude(x => x.Product).ThenInclude(x => x.PriceChanges)
            .Include(x => x.DeliveryInfos).ThenInclude(x => x.Product).ThenInclude(x => x.ChangesDetails)
            .Include(x => x.Store)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}
