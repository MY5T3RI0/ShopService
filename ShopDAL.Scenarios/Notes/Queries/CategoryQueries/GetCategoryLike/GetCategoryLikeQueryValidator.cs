using FluentValidation;
using MediatR;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductDetails;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductLike
{
    public class GetCategoryLikeQueryValidator : AbstractValidator<GetCategoryLikeQuery>, IRequest<CategoryLikeVm>
    {
        public GetCategoryLikeQueryValidator()
        {
            RuleFor(entityQuery => entityQuery.SearchString).NotEmpty().Length(1, 50);
        }
    }
}
