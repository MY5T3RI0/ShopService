using AutoMapper;
using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductDetails
{
    public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, ProductDetailsVm>
    {
        private readonly IRepoService<Product> _service;
        private readonly IMapper _mapper;

        public GetProductDetailsQueryHandler(IRepoService<Product> service, IMapper mapper)
        {
            if (service is null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            if (mapper is null)
            {
                throw new ArgumentNullException(nameof(mapper));
            }

            (_service, _mapper) = (service, mapper);
        }

        public async Task<ProductDetailsVm> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = await _service.GetOneAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Product), request.Id);

            return _mapper.Map<ProductDetailsVm>(entity);
        }
    }
}
