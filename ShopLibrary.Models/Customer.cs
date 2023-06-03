using ShopDAL.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopDAL.Models
{
    [Table("Customer")]
    public class Customer : EntityBase
    {
        public string Name { get; set; }
    }
}
