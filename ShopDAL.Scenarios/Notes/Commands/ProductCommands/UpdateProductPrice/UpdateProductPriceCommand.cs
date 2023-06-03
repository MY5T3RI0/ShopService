using MediatR;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductPriceCommand : IRequest
    {
        public int Id { get; set; }

    }
}
