using ShopDAL.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopDAL.Models
{
    [Table("Store")]
    public class Store : EntityBase
    {
        public string Name { get; set; }
        public List<ProductsInStore> ProductsInStore { get; set; }
        public List<StoreProducts> StoreProducts { get; set; }
        public List<Purchase> Purchases { get; set; }
        public List<Delivery> Deliveries { get; set; }
    }
}
