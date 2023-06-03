using ShopDAL.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopDAL.Models
{
    [Table("StoreProducts")]
    public class StoreProducts : EntityBase
    {
        public Store Store { get; set; }
        public int StoreId { get; set; }
        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; }

        public List<PurchaseDetails> PurchaseDetails { get; set; }
    }
}