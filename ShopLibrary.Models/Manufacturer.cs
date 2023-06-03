using ShopDAL.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopDAL.Models
{
    [Table("Manufacturer")]
    public class Manufacturer : EntityBase
    {
        public string Name { get; set; }
    }
}
