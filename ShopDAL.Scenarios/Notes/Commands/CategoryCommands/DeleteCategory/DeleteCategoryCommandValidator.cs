using FluentValidation;
using MediatR;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.DeleteProduct
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>, IRequest
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(entityCommand => entityCommand.Id).GreaterThanOrEqualTo(0);
        }
    }
}
