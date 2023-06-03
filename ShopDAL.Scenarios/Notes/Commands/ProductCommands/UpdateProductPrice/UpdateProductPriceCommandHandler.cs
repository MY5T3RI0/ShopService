using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductPriceCommandHandler : IRequestHandler<UpdateProductPriceCommand>
    {
        private readonly IRepoService<Product> _service;

        public UpdateProductPriceCommandHandler(IRepoService<Product> service) =>
            _service = service ?? throw new ArgumentNullException(nameof(service));

        public async Task Handle(UpdateProductPriceCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = await _service.GetRelatedDataAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Product), request.Id);

            entity.Price = entity.PriceChanges.Where(x => x.ChangesDetails
            .Any(x => x.ProductId == request.Id)).OrderByDescending(x => x.DateOfChange)
            .First().ChangesDetails.Where(x => x.ProductId == request.Id).First().NewPrice;

            await _service.UpdateAsync(entity);
        }
    }
}
