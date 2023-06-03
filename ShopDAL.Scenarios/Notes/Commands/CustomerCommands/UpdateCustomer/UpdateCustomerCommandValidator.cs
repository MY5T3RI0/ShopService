using FluentValidation;
using MediatR;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>, IRequest
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(entityCommand => entityCommand.Id).GreaterThanOrEqualTo(0);
            RuleFor(entityCommand => entityCommand.Name).NotEmpty().MaximumLength(250);
        }
    }
}
