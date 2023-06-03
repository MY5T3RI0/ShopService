using FluentValidation;
using MediatR;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductLike
{
    public class GetProductLikeQueryValidator : AbstractValidator<GetProductLikeQuery>, IRequest<ProductLikeVm>
    {
        public GetProductLikeQueryValidator()
        {
            RuleFor(entityQuery => entityQuery.SearchString).NotEmpty().Length(0, 50);
        }
    }
}
