using Microsoft.EntityFrameworkCore;
using ShopDAL.Models;
using ShopDAL.Repos.Interfaces;
using ShopDAL.Scenarios.Interfaces;

namespace ShopDAL.Repos
{
    public class PriceChangeRepo<T> : BaseRepo<PriceChange>, IPriceChangeRepo
    {
        public List<PriceChange> GetRelatedData() => Context.PriceChanges.FromSql($"SELECT * FROM PriceChange")
            .Include(x => x.ChangesDetails).ThenInclude(x => x.Product).ThenInclude(x => x.Manufacturer)
            .Include(x => x.ChangesDetails).ThenInclude(x => x.Product).ThenInclude(x => x.Category)
            .ToList();

        public async Task<List<PriceChange>> GetRelatedDataAsync() => await Context.PriceChanges.FromSql($"SELECT * FROM PriceChange")
            .Include(x => x.ChangesDetails).ThenInclude(x => x.Product).ThenInclude(x => x.Manufacturer)
            .Include(x => x.ChangesDetails).ThenInclude(x => x.Product).ThenInclude(x => x.Category)
            .ToListAsync();

        public async Task<PriceChange> GetRelatedDataAsync(int id) => await Context.PriceChanges.FromSql($"SELECT * FROM PriceChange")
            .Include(x => x.ChangesDetails).ThenInclude(x => x.Product).ThenInclude(x => x.Manufacturer)
            .Include(x => x.ChangesDetails).ThenInclude(x => x.Product).ThenInclude(x => x.Category)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}