using MediatR;

namespace ShopDAL.Scenarios.Notes.Queries.PriceChangeQueries.GetPriceChangeDetails
{
    public class GetPriceChangeDetailsQuery : IRequest<PriceChangeDetailsVm>
    {
        public int Id { get; set; }
    }
}
