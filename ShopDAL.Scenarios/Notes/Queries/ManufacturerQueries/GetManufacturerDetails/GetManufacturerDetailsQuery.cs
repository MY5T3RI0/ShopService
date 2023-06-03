using MediatR;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductDetails
{
    public class GetManufacturerDetailsQuery : IRequest<ManufacturerDetailsVm>
    {
        public int Id { get; set; }
    }
}
