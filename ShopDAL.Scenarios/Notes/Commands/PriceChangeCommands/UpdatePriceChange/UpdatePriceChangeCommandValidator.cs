using FluentValidation;
using MediatR;
using ShopDAL.Models;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct
{
    public class UpdatePriceChangeCommandValidator : AbstractValidator<UpdatePriceChangeCommand>, IRequest
    {
        public UpdatePriceChangeCommandValidator()
        {
            RuleFor(entityCommand => entityCommand.Id).GreaterThanOrEqualTo(0);
            RuleFor(entityCommand => entityCommand.Date).InclusiveBetween(DateOnly.FromDateTime(DateTime.Now.AddYears(-100)), DateOnly.FromDateTime(DateTime.Now));
            RuleFor(entityCommand => entityCommand.ChangesDetails).NotEmpty().Must(BeAValidChangesDetails);
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
