using MediatR;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct
{
    public class UpdateManufacturerCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
