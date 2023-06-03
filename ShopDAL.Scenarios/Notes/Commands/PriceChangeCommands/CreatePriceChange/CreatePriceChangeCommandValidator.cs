using FluentValidation;
using MediatR;
using ShopDAL.Models;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct
{
    public class CreatePriceChangeCommandValidator : AbstractValidator<CreatePriceChangeCommand>, IRequest<int>
    {
        public CreatePriceChangeCommandValidator()
        {
            RuleFor(entityCommand => entityCommand.ChangeDetails).NotEmpty().Must(BeAValidChangesDetails);
        }

        private bool BeAValidChangesDetails(List<ChangesDetails> changesDetails)
        {
            bool result;
            foreach (var changesDetail in changesDetails)
            {
                result = changesDetail.ProductId >= 0 ? true : false;
                result = changesDetail.NewPrice >= 0 && result ? true : false;

                if (!result) return false;
            }
            return true;
        }
    }
}
