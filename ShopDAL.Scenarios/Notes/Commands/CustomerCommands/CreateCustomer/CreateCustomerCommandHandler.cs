using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly IRepoService<Customer> _service;

        public CreateCustomerCommandHandler(IRepoService<Customer> service) =>
            _service = service ?? throw new ArgumentNullException(nameof(service));
        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = new Customer
            {
                Name = request.Name
            };

            await _service.AddAsync(entity);

            return entity.Id;
        }
    }
}
