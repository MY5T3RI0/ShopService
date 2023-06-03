using MediatR;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductLike
{
    public class GetProductLikeQuery : IRequest<ProductLikeVm>
    {
        public string SearchString { get; set; }
    }
}
