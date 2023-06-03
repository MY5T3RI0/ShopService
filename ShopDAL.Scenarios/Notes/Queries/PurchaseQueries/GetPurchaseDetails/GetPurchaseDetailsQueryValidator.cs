using FluentValidation;
using MediatR;

namespace ShopDAL.Scenarios.Notes.Queries.PurchaseQueries.GetPurchaseDetails
{
    public class GetPurchaseDetailsQueryValidator : AbstractValidator<GetPurchaseDetailsQuery>, IRequest<PurchaseDetailsVm>
    {
        public GetPurchaseDetailsQueryValidator()
        {
            RuleFor(entityQuery => entityQuery.Id).GreaterThanOrEqualTo(0);
        }
    }
}
