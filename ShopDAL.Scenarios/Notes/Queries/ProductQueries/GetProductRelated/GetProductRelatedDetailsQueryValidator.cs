using FluentValidation;
using MediatR;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductDetails;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductRelated
{
    public class GetProductRelatedDetailsQueryValidator : AbstractValidator<GetProductRelatedDetailsQuery>, IRequest<ProductRelatedDetailsVm>
    {
        public GetProductRelatedDetailsQueryValidator()
        {
            RuleFor(entityQuery => entityQuery.Id).GreaterThanOrEqualTo(0);
        }
    }
}
