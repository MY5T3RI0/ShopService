using MediatR;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.DeleteProduct
{
    public class DeleteDeliveryCommand : IRequest
    {
        public int Id { get; set; }
    }
}
