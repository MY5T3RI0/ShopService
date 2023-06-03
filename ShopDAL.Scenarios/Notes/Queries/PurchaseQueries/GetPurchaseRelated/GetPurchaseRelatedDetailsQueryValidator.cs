using FluentValidation;
using MediatR;
using ShopDAL.Scenarios.Notes.Queries.PurchaseQueries.GetPurchaseDetails;

namespace ShopDAL.Scenarios.Notes.Queries.PurchaseQueries.GetPurchaseRelated
{
    public class GetPurchaseRelatedDetailsQueryValidator : AbstractValidator<GetPurchaseRelatedDetailsQuery>, IRequest<PurchaseRelatedDetailsVm>
    {
        public GetPurchaseRelatedDetailsQueryValidator()
        {
            RuleFor(entityQuery => entityQuery.Id).GreaterThanOrEqualTo(0);
        }
    }
}
