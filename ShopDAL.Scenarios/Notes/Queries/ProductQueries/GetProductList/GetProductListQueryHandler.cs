using AutoMapper;
using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, ProductListVm>
    {
        private readonly IRepoService<Product> _service;
        private readonly IMapper _mapper;

        public GetProductListQueryHandler(IRepoService<Product> service,
            IMapper mapper)
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

        public async Task<ProductListVm> Handle(GetProductListQuery request,
            CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var products = await _service.GetAllAsync();

            if (products == null)
                throw new NotFoundException(nameof(Product), request);

            var productsQuery = products.Select(_mapper.Map<ProductLookupDto>).ToList();

            return new ProductListVm { Products = productsQuery };
        }
    }
}
