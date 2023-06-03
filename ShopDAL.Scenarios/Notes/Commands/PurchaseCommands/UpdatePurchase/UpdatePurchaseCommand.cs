using MediatR;
using ShopDAL.Models;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct
{
    public class UpdatePurchaseCommand : IRequest
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateOnly Date { get; set; }
        public List<StoreProducts> StoreProducts { get; set; }
    }
}
