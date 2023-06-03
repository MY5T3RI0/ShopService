using FluentValidation;
using MediatR;
using ShopDAL.Scenarios.Notes.Queries.PriceChangeQueries.GetPriceChangeDetails;

namespace ShopDAL.Scenarios.Notes.Queries.PriceChangeQueries.GetPriceChangeRelated
{
    public class GetPriceChangeRelatedDetailsQueryValidator : AbstractValidator<GetPriceChangeRelatedDetailsQuery>, IRequest<PriceChangeRelatedDetailsVm>
    {
        public GetPriceChangeRelatedDetailsQueryValidator()
        {
            RuleFor(entityQuery => entityQuery.Id).GreaterThanOrEqualTo(0);
        }
    }
}
