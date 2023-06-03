using ShopDAL.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopDAL.Models
{
    [Table("Category")]
    public class Category : EntityBase
    {
        public string Name { get; set; }
    }
}
