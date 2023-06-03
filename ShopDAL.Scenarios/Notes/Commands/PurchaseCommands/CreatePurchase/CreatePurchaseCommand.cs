using MediatR;
using ShopDAL.Models;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct
{
    public class CreatePurchaseCommand : IRequest<int>
    {
        public int CustomerId { get; set; }
        public List<StoreProducts> StoreProducts { get; set; }
    }
}
