using MediatR;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.DeleteProduct
{
    public class DeletePurchaseCommand : IRequest
    {
        public int Id { get; set; }
    }
}
