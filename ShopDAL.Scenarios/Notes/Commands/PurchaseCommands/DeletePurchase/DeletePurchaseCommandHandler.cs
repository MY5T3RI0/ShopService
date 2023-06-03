using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.DeleteProduct
{
    public class DeletePurchaseCommandHandler : IRequestHandler<DeletePurchaseCommand>
    {
        private readonly IRepoService<Purchase> _service;

        public DeletePurchaseCommandHandler(IRepoService<Purchase> service) =>
            _service = service ?? throw new ArgumentNullException(nameof(service));

        public async Task Handle(DeletePurchaseCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = await _service.GetOneAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Purchase), request.Id);

            await _service.DeleteAsync(entity);
        }
    }
}
