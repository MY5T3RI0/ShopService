using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.DeleteProduct
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IRepoService<Category> _service;

        public DeleteCategoryCommandHandler(IRepoService<Category> service) =>
            _service = service ?? throw new ArgumentNullException(nameof(service));

        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = await _service.GetOneAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Category), request.Id);

            await _service.DeleteAsync(entity);
        }
    }
}
