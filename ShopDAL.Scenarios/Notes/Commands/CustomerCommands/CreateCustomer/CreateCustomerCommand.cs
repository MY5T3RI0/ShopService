using MediatR;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct
{
    public class CreateCustomerCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
