using MediatR;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductDetails;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductLike
{
    public class GetCustomerLikeQuery : IRequest<CustomerLikeVm>
    {
        public string SearchString { get; set; }
    }
}
