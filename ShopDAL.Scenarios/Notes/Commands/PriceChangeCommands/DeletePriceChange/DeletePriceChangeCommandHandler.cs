using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.DeleteProduct
{
    public class DeletePriceChangeCommandHandler : IRequestHandler<DeletePriceChangeCommand>
    {
        private readonly IRepoService<PriceChange> _service;

        public DeletePriceChangeCommandHandler(IRepoService<PriceChange> service) =>
            _service = service ?? throw new ArgumentNullException(nameof(service));

        public async Task Handle(DeletePriceChangeCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = await _service.GetOneAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(PriceChange), request.Id);

            await _service.DeleteAsync(entity);
        }
    }
}
