using FluentValidation;
using MediatR;

namespace ShopDAL.Scenarios.Notes.Queries.StoreQueries.GetStoreDetails
{
    public class GetStoreDetailsQueryValidator : AbstractValidator<GetStoreDetailsQuery>, IRequest<StoreDetailsVm>
    {
        public GetStoreDetailsQueryValidator()
        {
            RuleFor(entityQuery => entityQuery.Id).GreaterThanOrEqualTo(0);
        }
    }
}
