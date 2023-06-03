using FluentValidation;
using MediatR;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.DeleteProduct
{
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>, IRequest
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(entityCommand => entityCommand.Id).GreaterThanOrEqualTo(0);
        }
    }
}
