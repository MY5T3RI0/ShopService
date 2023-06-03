using FluentValidation;
using MediatR;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>, IRequest
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(entityCommand => entityCommand.Id).GreaterThanOrEqualTo(0);
            RuleFor(entityCommand => entityCommand.Name).NotEmpty().Must(cat => cat.Any(char.IsLetter)).MaximumLength(250);
        }

    }
}
