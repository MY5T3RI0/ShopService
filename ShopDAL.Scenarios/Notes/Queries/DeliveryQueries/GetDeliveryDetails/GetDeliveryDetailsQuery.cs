using MediatR;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductDetails
{
    public class GetDeliveryDetailsQuery : IRequest<DeliveryDetailsVm>
    {
        public int Id { get; set; }
    }
}
