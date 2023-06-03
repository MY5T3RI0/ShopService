using MediatR;
using ShopDAL.Models;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct
{
    public class UpdateStoreCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
