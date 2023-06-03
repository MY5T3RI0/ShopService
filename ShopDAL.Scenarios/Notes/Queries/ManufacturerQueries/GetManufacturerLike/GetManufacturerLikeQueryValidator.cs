using FluentValidation;
using MediatR;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductDetails;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductLike
{
    public class GetManufacturerLikeQueryValidator : AbstractValidator<GetManufacturerLikeQuery>, IRequest<ManufacturerLikeVm>
    {
        public GetManufacturerLikeQueryValidator()
        {
            RuleFor(entityQuery => entityQuery.SearchString).NotEmpty().Length(0, 50);
        }
    }
}
