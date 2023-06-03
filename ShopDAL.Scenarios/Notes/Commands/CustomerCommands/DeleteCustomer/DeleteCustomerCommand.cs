using MediatR;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.DeleteProduct
{
    public class DeleteCustomerCommand : IRequest
    {
        public int Id { get; set; }
    }
}
