using FluentValidation;
using MediatR;
using ShopDAL.Scenarios.Notes.Queries.StoreQueries.GetStoreDetails;

namespace ShopDAL.Scenarios.Notes.Queries.StoreQueries.GetStoreRelated
{
    public class GetStoreRelatedDetailsQueryValidator : AbstractValidator<GetStoreRelatedDetailsQuery>, IRequest<StoreRelatedDetailsVm>
    {
        public GetStoreRelatedDetailsQueryValidator()
        {
            RuleFor(entityQuery => entityQuery.Id).GreaterThanOrEqualTo(0);
        }
    }
}
