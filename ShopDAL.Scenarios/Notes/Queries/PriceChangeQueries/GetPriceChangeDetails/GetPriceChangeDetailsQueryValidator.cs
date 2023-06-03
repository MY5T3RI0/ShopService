using FluentValidation;
using MediatR;

namespace ShopDAL.Scenarios.Notes.Queries.PriceChangeQueries.GetPriceChangeDetails
{
    public class GetPriceChangeDetailsQueryValidator : AbstractValidator<GetPriceChangeDetailsQuery>, IRequest<PriceChangeDetailsVm>
    {
        public GetPriceChangeDetailsQueryValidator()
        {
            RuleFor(entityQuery => entityQuery.Id).GreaterThanOrEqualTo(0);
        }
    }
}
