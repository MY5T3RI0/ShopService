using MediatR;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManufacturerId { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string ImageName { get; set; }
    }
}
