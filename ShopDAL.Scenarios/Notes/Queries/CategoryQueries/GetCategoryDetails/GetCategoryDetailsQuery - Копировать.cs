using FluentValidation;
using MediatR;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductDetails
{
    public class GetCategoryDetailsQueryValidator : AbstractValidator<GetCategoryDetailsQuery>, IRequest<CategoryDetailsVm>
    {
        public GetCategoryDetailsQueryValidator()
        {
            RuleFor(entityQuery => entityQuery.Id).GreaterThanOrEqualTo(0);
        }
    }
}
