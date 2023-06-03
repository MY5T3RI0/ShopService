using MediatR;

namespace ShopDAL.Scenarios.Notes.Queries.PurchaseQueries.GetPurchaseDetails
{
    public class GetPurchaseDetailsQuery : IRequest<PurchaseDetailsVm>
    {
        public int Id { get; set; }
    }
}
