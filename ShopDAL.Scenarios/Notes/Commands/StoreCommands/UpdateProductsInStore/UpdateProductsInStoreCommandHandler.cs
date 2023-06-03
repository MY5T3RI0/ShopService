using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductsInStoreCommandHandler : IRequestHandler<UpdateProductsInStoreCommand>
    {
        private readonly IRepoService<Store> _service;

        public UpdateProductsInStoreCommandHandler(IRepoService<Store> service) =>
            _service = service ?? throw new ArgumentNullException(nameof(service));

        public async Task Handle(UpdateProductsInStoreCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = await _service.GetRelatedDataAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Store), request.Id);

            entity.Id = request.Id;

            foreach(var product in request.ProductsToChange)
            {
                try
                {
                    var temprodInStore = entity.ProductsInStore.Find(x => x.ProductId == product.ProductId) ?? throw new NotFoundException(nameof(ProductsInStore), product.ProductId);
                    temprodInStore.Count += product.ProductCount;
                    if(temprodInStore.Count < 0) throw new AbsenceException(nameof(Product), product.ProductId);
                }
                catch (NotFoundException ex)
                {
                    entity.ProductsInStore.Add(new ProductsInStore { ProductId = product.ProductId, Count = product.ProductCount });
                }

            }

            await _service.UpdateAsync(entity);
        }
    }
}
