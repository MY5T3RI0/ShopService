using MediatR;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductDetails;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductLike
{
    public class GetCategoryLikeQuery : IRequest<CategoryLikeVm>
    {
        public string SearchString { get; set; }
    }
}
