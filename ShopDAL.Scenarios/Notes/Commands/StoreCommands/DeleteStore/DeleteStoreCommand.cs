using MediatR;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.DeleteProduct
{
    public class DeleteStoreCommand : IRequest
    {
        public int Id { get; set; }
    }
}
