using FluentValidation;
using MediatR;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductDetails
{
    public class GetDeliveryRelatedDetailsQueryValidator : AbstractValidator<GetDeliveryRelatedDetailsQuery>, IRequest<DeliveryRelatedDetailsVm>
    {
        public GetDeliveryRelatedDetailsQueryValidator()
        {
            RuleFor(entityQuery => entityQuery.Id).GreaterThanOrEqualTo(0);
        }
    }
}
