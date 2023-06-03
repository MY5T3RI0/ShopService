using FluentValidation;
using MediatR;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductDetails;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductLike
{
    public class GetDeliveryLikeQueryValidator : AbstractValidator<GetDeliveryLikeQuery>, IRequest<DeliveryLikeVm>
    {
        public GetDeliveryLikeQueryValidator()
        {
            RuleFor(entityQuery => entityQuery.SearchString).NotEmpty().Length(0, 50).Must(date => !date.Any(char.IsLetter));
        }
    }
}
