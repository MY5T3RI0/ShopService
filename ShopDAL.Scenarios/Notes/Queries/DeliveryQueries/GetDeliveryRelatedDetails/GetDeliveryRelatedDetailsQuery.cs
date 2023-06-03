using MediatR;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductDetails
{
    public class GetDeliveryRelatedDetailsQuery : IRequest<DeliveryRelatedDetailsVm>
    {
        public int Id { get; set; }
    }
}
