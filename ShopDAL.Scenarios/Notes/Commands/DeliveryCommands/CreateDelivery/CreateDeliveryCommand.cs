using MediatR;
using ShopDAL.Models;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct
{
    public class CreateDeliveryCommand : IRequest<int>
    {
        public int StoreId { get; set; }
        public List<DeliveryInfo> DeliveryInfos { get; set; }

    }
}
