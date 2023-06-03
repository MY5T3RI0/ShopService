using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct
{
    public class UpdatePurchaseCommandHandler : IRequestHandler<UpdatePurchaseCommand>
    {
        private readonly IRepoService<Purchase> _service;

        public UpdatePurchaseCommandHandler(IRepoService<Purchase> service) =>
            _service = service ?? throw new ArgumentNullException(nameof(service));

        public async Task Handle(UpdatePurchaseCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = await _service.GetOneAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Purchase), request.Id);

            entity.Date = request.Date;
            entity.Id = request.Id;
            entity.CustomerId = request.CustomerId;
            entity.StoreProducts = request.StoreProducts;

            await _service.UpdateAsync(entity);
        }
    }
}
