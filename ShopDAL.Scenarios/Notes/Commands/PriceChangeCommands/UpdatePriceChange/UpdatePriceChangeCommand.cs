using MediatR;
using ShopDAL.Models;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct
{
    public class UpdatePriceChangeCommand : IRequest
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public List<ChangesDetails> ChangesDetails { get; set; }
    }
}
