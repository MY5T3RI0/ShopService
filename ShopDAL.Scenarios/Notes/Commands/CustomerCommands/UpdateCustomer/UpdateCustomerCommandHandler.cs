using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly IRepoService<Customer> _service;

        public UpdateCustomerCommandHandler(IRepoService<Customer> service) =>
            _service = service ?? throw new ArgumentNullException(nameof(service));

        public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = await _service.GetOneAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Customer), request.Id);

            entity.Name = request.Name;
            entity.Id = request.Id;

            await _service.UpdateAsync(entity);
        }
    }
}
