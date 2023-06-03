using MediatR;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct
{
    public class CreateManufacturerCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
