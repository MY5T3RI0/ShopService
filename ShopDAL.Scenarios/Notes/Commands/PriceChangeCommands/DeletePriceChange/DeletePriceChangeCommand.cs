using MediatR;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.DeleteProduct
{
    public class DeletePriceChangeCommand : IRequest
    {
        public int Id { get; set; }
    }
}
