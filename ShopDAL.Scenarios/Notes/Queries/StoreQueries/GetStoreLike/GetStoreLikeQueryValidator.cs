using FluentValidation;
using MediatR;

namespace ShopDAL.Scenarios.Notes.Queries.StoreQueries.GetStoreLike
{
    public class GetStoreLikeQueryValidator : AbstractValidator<GetStoreLikeQuery>, IRequest<StoreLikeVm>
    {
        public GetStoreLikeQueryValidator()
        {
            RuleFor(entityQuery => entityQuery.SearchString).NotEmpty().Length(0, 50);
        }
    }
}
