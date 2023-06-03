using FluentValidation;
using MediatR;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductDetails
{
    public class GetDeliveryDetailsQueryValidator : AbstractValidator<GetDeliveryDetailsQuery>, IRequest<DeliveryDetailsVm>
    {
        public GetDeliveryDetailsQueryValidator()
        {
            RuleFor(entityQuery => entityQuery.Id).GreaterThanOrEqualTo(0);
        }
    }
}
