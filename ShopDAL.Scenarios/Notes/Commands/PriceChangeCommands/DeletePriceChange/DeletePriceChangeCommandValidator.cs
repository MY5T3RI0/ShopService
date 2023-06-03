using FluentValidation;
using MediatR;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.DeleteProduct
{
    public class DeletePriceChangeCommandValidator : AbstractValidator<DeletePriceChangeCommand>, IRequest
    {
        public DeletePriceChangeCommandValidator()
        {
            RuleFor(entityCommand => entityCommand.Id).GreaterThanOrEqualTo(0);
        }
    }
}
