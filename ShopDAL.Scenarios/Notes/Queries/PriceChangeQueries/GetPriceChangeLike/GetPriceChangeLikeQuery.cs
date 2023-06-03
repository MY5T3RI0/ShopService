using MediatR;
using ShopDAL.Scenarios.Notes.Queries.PriceChangeQueries.GetPriceChangeDetails;

namespace ShopDAL.Scenarios.Notes.Queries.PriceChangeQueries.GetPriceChangeLike
{
    public class GetPriceChangeLikeQuery : IRequest<PriceChangeLikeVm>
    {
        public string SearchString { get; set; }
    }
}
