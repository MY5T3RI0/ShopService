using MediatR;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.DeleteProduct
{
    public class DeleteCategoryCommand : IRequest
    {
        public int Id { get; set; }
    }
}
