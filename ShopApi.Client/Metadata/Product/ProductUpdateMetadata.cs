using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Client.Metadata.Product
{
    public class ProductUpdateMetadata
    {
        [Required(ErrorMessage ="Please enter product name")]
        [MinLength(5, ErrorMessage ="Too short name, must be 5 or greater")]
        [MaxLength(50, ErrorMessage = "Too long name, must be 50 or less")]
        public string Name { get; set; }

        [Required]
        [Range(1, 999999999, ErrorMessage = "Incorrect price, must be in range from 1 to 999999999")]
        public double Price { get; set; }

        [Required]
        [Range(0, 999999999, ErrorMessage = "Incorrect category")]
        public int CategoryId { get; set; }

        [Required]
        [Range(0, 999999999, ErrorMessage = "Incorrect manufacturer")]
        public int ManufacturerId { get; set; }

    }
}
