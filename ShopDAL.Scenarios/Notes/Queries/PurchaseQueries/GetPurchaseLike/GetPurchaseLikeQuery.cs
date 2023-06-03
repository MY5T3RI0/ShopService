using MediatR;
using ShopDAL.Scenarios.Notes.Queries.PurchaseQueries.GetPurchaseDetails;

namespace ShopDAL.Scenarios.Notes.Queries.PurchaseQueries.GetPurchaseLike
{
    public class GetPurchaseLikeQuery : IRequest<PurchaseLikeVm>
    {
        public string SearchString { get; set; }
    }
}
