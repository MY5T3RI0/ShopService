using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct
{
    public class UpdateDeliveryCommandHandler : IRequestHandler<UpdateDeliveryCommand>
    {
        private readonly IRepoService<Delivery> _service;

        public UpdateDeliveryCommandHandler(IRepoService<Delivery> service) =>
            _service = service ?? throw new ArgumentNullException(nameof(service));

        public async Task Handle(UpdateDeliveryCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = await _service.GetOneAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Delivery), request.Id);

            entity.Date = request.Date;
            entity.StoreId = request.StoreId;
            entity.DeliveryInfos = request.DeliveryInfos;
            entity.DeliveryInfos.Select(x => x.DeliveryId = entity.Id);

            await _service.UpdateAsync(entity);
        }
    }
}
