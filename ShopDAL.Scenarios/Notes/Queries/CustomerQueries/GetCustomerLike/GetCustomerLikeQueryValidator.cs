using FluentValidation;
using MediatR;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductDetails;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductLike
{
    public class GetCustomerLikeQueryValidator : AbstractValidator<GetCustomerLikeQuery>, IRequest<CustomerLikeVm>
    {
        public GetCustomerLikeQueryValidator()
        {
            RuleFor(entityQuery => entityQuery.SearchString).NotEmpty().Length(1, 50);
        }
    }
}
