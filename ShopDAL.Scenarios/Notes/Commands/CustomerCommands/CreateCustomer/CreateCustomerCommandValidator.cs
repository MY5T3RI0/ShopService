using FluentValidation;
using MediatR;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>, IRequest<int>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(entityCommand =>
                entityCommand.Name).NotEmpty().MaximumLength(250);
        }
    }
}
