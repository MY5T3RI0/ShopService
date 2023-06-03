using MediatR;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductDetails;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductLike
{
    public class GetDeliveryLikeQuery : IRequest<DeliveryLikeVm>
    {
        public string SearchString { get; set; }
    }
}
