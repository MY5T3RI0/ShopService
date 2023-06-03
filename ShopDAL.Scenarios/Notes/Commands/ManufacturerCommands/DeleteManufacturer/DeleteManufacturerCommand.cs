using MediatR;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.DeleteProduct
{
    public class DeleteManufacturerCommand : IRequest
    {
        public int Id { get; set; }
    }
}
