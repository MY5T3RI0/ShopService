using ShopDAL.DataInitialization;
using ShopDAL.EF;
using ShopDAL.Models;
using ShopDAL.Repos;

var context = new ShopContextFactory().CreateDbContext(null);

//DataInitializer.RecreateDatabase(context);
DataInitializer.ClearData(context);
DataInitializer.InitializeData(context);

using (var repo = new StoreRepo<Store>())
{
    foreach (var x in repo.GetRelatedData())
    {
        if (x.Id == 3)
            foreach (var y in x.Deliveries)
                Console.WriteLine(y.Date);
    }
}