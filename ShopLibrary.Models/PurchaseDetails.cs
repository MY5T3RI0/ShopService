using ShopDAL.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopDAL.Models
{
    [Table("PurchaseDetails")]
    public class PurchaseDetails : EntityBase
    {
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public int StoreProductsId { get; set; }

        [ForeignKey(nameof(StoreProductsId))]
        public StoreProducts StoreProducts { get; set; }
        public int Discount { get; set; }
        public int ProductCount { get; set; }

    }
}
