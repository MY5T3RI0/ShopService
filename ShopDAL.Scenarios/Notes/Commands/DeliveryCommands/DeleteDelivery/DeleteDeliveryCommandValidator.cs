using FluentValidation;
using MediatR;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.DeleteProduct
{
    public class DeleteDeliveryCommandValidator : AbstractValidator<DeleteDeliveryCommand>, IRequest
    {
        public DeleteDeliveryCommandValidator()
        {
            RuleFor(entityCommand => entityCommand.Id).GreaterThanOrEqualTo(0);
        }
    }
}
