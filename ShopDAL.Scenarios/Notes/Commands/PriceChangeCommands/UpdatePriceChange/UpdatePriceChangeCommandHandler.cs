using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct
{
    public class UpdatePriceChangeCommandHandler : IRequestHandler<UpdatePriceChangeCommand>
    {
        private readonly IRepoService<PriceChange> _service;

        public UpdatePriceChangeCommandHandler(IRepoService<PriceChange> service) =>
            _service = service ?? throw new ArgumentNullException(nameof(service));

        public async Task Handle(UpdatePriceChangeCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = await _service.GetOneAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(PriceChange), request.Id);

            entity.DateOfChange = request.Date;
            entity.Id = request.Id;
            entity.ChangesDetails = request.ChangesDetails;

            await _service.DeleteAsync(entity);
            await _service.AddAsync(entity);
        }
    }
}
