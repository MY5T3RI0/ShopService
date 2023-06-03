using ShopDAL.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopDAL.Models
{
    [Table("PriceChange")]
    public class PriceChange : EntityBase
    {
        public DateOnly DateOfChange { get; set; }

        public List<Product> Products { get; set; }
        public List<ChangesDetails> ChangesDetails { get; set; }
    }
}
