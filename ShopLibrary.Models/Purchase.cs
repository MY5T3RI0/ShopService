using ShopDAL.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopDAL.Models
{
    [Table("Purchase")]
    public class Purchase : EntityBase
    {
        public DateOnly Date { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }

        public List<Store> Stores { get; set; }
        public List<StoreProducts> StoreProducts { get; set; }
    }
}
