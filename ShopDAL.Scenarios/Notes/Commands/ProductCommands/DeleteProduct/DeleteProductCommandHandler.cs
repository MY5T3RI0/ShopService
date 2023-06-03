﻿using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IRepoService<Product> _service;

        public DeleteProductCommandHandler(IRepoService<Product> service) =>
            _service = service ?? throw new ArgumentNullException(nameof(service));

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = await _service.GetOneAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Product), request.Id);

            await _service.DeleteAsync(entity);
        }
    }
}
