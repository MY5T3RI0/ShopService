using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.DeleteProduct
{
    public class DeleteStoreCommandHandler : IRequestHandler<DeleteStoreCommand>
    {
        private readonly IRepoService<Store> _service;

        public DeleteStoreCommandHandler(IRepoService<Store> service) =>
            _service = service ?? throw new ArgumentNullException(nameof(service));

        public async Task Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = await _service.GetOneAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Store), request.Id);

            await _service.DeleteAsync(entity);
        }
    }
}
