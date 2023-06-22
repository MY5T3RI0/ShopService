using ShopDAL.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopDAL.Models
{
    [Table("Product")]
    public class Product : EntityBase
    {
        public string? Name { get; set; }
        public int ManufacturerId { get; set; }

        [ForeignKey(nameof(ManufacturerId))]
        public Manufacturer? Manufacturer { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }
        public decimal Price { get; set; }
        public string ImageName { get; set; }
        public List<PriceChange> PriceChanges { get; set; }
        public List<ChangesDetails> ChangesDetails { get; set; }
        public Product()
        {
            PriceChanges = new List<PriceChange>();
            ChangesDetails = new List<ChangesDetails>();
        }
    }
}
