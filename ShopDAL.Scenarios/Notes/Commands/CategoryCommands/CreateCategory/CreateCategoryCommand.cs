using MediatR;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
