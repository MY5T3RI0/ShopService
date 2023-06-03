using MediatR;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductDetails
{
    public class GetCategoryDetailsQuery : IRequest<CategoryDetailsVm>
    {
        public int Id { get; set; }
    }
}
