using MediatR;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int ManufacturerId { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

    }
}
