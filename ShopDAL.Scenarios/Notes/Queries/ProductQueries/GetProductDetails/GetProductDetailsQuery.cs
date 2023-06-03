using MediatR;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductDetails
{
    public class GetProductDetailsQuery : IRequest<ProductDetailsVm>
    {
        public int Id { get; set; }
    }
}
