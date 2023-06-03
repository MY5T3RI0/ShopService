using System.ComponentModel.DataAnnotations.Schema;

namespace ShopDAL.Models
{
    [Table("ChangesDetails")]
    public class ChangesDetails
    {
        public int PriceChangesId { get; set; }
        public PriceChange PriceChange { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public decimal NewPrice { get; set; }
    }
}