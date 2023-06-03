using FluentValidation;
using MediatR;
using ShopDAL.Scenarios.Notes.Queries.PriceChangeQueries.GetPriceChangeDetails;

namespace ShopDAL.Scenarios.Notes.Queries.PriceChangeQueries.GetPriceChangeLike
{
    public class GetPriceChangeLikeQueryValidator : AbstractValidator<GetPriceChangeLikeQuery>, IRequest<PriceChangeLikeVm>
    {
        public GetPriceChangeLikeQueryValidator()
        {
            RuleFor(entityQuery => entityQuery.SearchString).NotEmpty().Length(0, 50).Must(date => !date.Any(char.IsLetter));
        }
    }
}
