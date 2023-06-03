using MediatR;
using ShopDAL.Models;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct
{
    public class CreatePriceChangeCommand : IRequest<int>
    {
        public List<ChangesDetails> ChangeDetails { get; set; }
    }
}
