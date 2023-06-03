using FluentValidation;
using MediatR;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductDetails
{
    public class GetManufacturerDetailsQueryValidator : AbstractValidator<GetManufacturerDetailsQuery>, IRequest<ManufacturerDetailsVm>
    {
        public GetManufacturerDetailsQueryValidator()
        {
            RuleFor(entityQuery => entityQuery.Id).GreaterThanOrEqualTo(0);
        }
    }
}
