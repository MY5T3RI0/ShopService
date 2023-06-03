using FluentValidation;
using MediatR;
using ShopDAL.Models;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct
{
    public class UpdateStoreCommandValidator : AbstractValidator<UpdateStoreCommand>, IRequest
    {
        public UpdateStoreCommandValidator()
        {
            RuleFor(entityCommand => entityCommand.Name).NotEmpty();
            RuleFor(entityCommand => entityCommand.Id).GreaterThanOrEqualTo(0);
        }
    }
}
