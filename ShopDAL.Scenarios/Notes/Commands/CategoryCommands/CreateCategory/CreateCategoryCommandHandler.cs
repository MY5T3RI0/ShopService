using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly IRepoService<Category> _service;

        public CreateCategoryCommandHandler(IRepoService<Category> service) =>
            _service = service ?? throw new ArgumentNullException(nameof(service));
        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var category = new Category
            {
                Name = request.Name
            };

            await _service.AddAsync(category);

            return category.Id;
        }
    }
}
