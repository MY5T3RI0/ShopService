using MediatR;
using ShopDAL.Models;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct
{
    public class UpdateDeliveryCommand : IRequest
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public DateOnly Date { get; set; }
        public List<DeliveryInfo> DeliveryInfos { get; set; }
    }
}
