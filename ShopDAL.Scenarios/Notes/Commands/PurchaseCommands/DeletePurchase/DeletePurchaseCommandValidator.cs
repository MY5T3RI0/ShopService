using FluentValidation;
using MediatR;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.DeleteProduct
{
    public class DeletePurchaseCommandValidator : AbstractValidator<DeletePurchaseCommand>, IRequest
    {
        public DeletePurchaseCommandValidator()
        {
            RuleFor(entityCommand => entityCommand.Id).GreaterThanOrEqualTo(0);
        }
    }
}
