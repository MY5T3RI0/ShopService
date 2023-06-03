using MediatR;

namespace ShopDAL.Scenarios.Notes.Queries.StoreQueries.GetStoreDetails
{
    public class GetStoreDetailsQuery : IRequest<StoreDetailsVm>
    {
        public int Id { get; set; }
    }
}
