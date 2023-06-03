using MediatR;
using ShopDAL.Models;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct
{
    public class CreateStoreCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
