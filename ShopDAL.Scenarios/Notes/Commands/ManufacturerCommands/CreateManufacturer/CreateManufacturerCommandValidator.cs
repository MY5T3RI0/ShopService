using FluentValidation;
using MediatR;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct
{
    public class CreateManufacturerCommandValidator : AbstractValidator<CreateManufacturerCommand>, IRequest<int>
    {
        public CreateManufacturerCommandValidator()
        {
            RuleFor(entityCommand =>
                entityCommand.Name).NotEmpty().MaximumLength(250);
        }
    }
}
