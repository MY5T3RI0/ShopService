using MediatR;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductDetails
{
    public class GetCustomerDetailsQuery : IRequest<CustomerDetailsVm>
    {
        public int Id { get; set; }
    }
}
