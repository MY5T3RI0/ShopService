using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct
{
    public class UpdateStoreCommandHandler : IRequestHandler<UpdateStoreCommand>
    {
        private readonly IRepoService<Store> _service;

        public UpdateStoreCommandHandler(IRepoService<Store> service) =>
            _service = service ?? throw new ArgumentNullException(nameof(service));

        public async Task Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = await _service.GetOneAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Store), request.Id);

            entity.Name = request.Name;
            entity.Id = request.Id;

            await _service.UpdateAsync(entity);
        }
    }
}
