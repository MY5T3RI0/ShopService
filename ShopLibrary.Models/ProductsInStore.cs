using ShopDAL.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopDAL.Models
{
    [Table("ProductsInStore")]
    public class ProductsInStore : EntityBase
    {
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public int Count { get; set; }

        [ForeignKey(nameof(StoreId))]
        public Store Store { get; set; }
        public int StoreId { get; set; }
    }
}