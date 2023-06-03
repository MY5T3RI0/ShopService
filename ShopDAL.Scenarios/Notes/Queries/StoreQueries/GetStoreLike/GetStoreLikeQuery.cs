using MediatR;
using ShopDAL.Scenarios.Notes.Queries.StoreQueries.GetStoreDetails;

namespace ShopDAL.Scenarios.Notes.Queries.StoreQueries.GetStoreLike
{
    public class GetStoreLikeQuery : IRequest<StoreLikeVm>
    {
        public string SearchString { get; set; }
    }
}
