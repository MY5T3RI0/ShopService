using FluentValidation;
using MediatR;
using ShopDAL.Scenarios.Notes.Queries.PurchaseQueries.GetPurchaseDetails;

namespace ShopDAL.Scenarios.Notes.Queries.PurchaseQueries.GetPurchaseLike
{
    public class GetPurchaseLikeQueryValidator : AbstractValidator<GetPurchaseLikeQuery>, IRequest<PurchaseLikeVm>
    {
        public GetPurchaseLikeQueryValidator()
        {
            RuleFor(entityQuery => entityQuery.SearchString).NotEmpty().Length(0, 50).Must(date => !date.Any(char.IsLetter));
        }
    }
}
