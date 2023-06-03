using MediatR;
using ShopDAL.Models;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductsInStoreCommand : IRequest
    {
        public int Id { get; set; }
        public IEnumerable<(int ProductId, int ProductCount)> ProductsToChange { get; set; }
    }
}
