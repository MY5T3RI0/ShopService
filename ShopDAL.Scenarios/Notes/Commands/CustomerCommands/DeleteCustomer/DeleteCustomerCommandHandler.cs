using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.DeleteProduct
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly IRepoService<Customer> _service;

        public DeleteCustomerCommandHandler(IRepoService<Customer> service) =>
            _service = service ?? throw new ArgumentNullException(nameof(service));

        public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = await _service.GetOneAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Customer), request.Id);

            await _service.DeleteAsync(entity);
        }
    }
}
