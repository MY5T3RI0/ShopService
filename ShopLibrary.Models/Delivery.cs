using ShopDAL.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopDAL.Models
{
    [Table("Delivery")]
    public class Delivery : EntityBase
    {
        public DateOnly Date { get; set; }
        public int StoreId { get; set; }

        [ForeignKey(name: nameof(StoreId))]
        public Store Store { get; set; }

        //public List<Product> Products { get; set; }
        public List<DeliveryInfo> DeliveryInfos { get; set; }

        public Delivery()
        {
            DeliveryInfos = new List<DeliveryInfo>();
        }
    }
}
