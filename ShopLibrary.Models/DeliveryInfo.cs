using ShopDAL.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopDAL.Models
{
    [Table("DeliveryInfo")]
    public class DeliveryInfo : EntityBase
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int DeliveryId { get; set; }

        [ForeignKey(nameof(DeliveryId))]
        public Delivery Delivery { get; set; }
        public int ProductCount { get; set; }
    }
}
