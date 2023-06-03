using AutoMapper;
using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductRelatedList
{
    public class GetProductRelatedListQueryHandler : IRequestHandler<GetProductRelatedListQuery, ProductRelatedListVm>
    {
        private readonly IRepoService<Product> _service;
        private readonly IMapper _mapper;

        public GetProductRelatedListQueryHandler(IRepoService<Product> service,
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

        public async Task<ProductRelatedListVm> Handle(GetProductRelatedListQuery request,
            CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var products = await _service.GetRelatedDataAsync();

            if (products == null)
                throw new NotFoundException(nameof(Product), request);

            var productsQuery = products.Select(_mapper.Map<ProductRelatedLookupDto>).ToList();

            return new ProductRelatedListVm { Products = productsQuery };
        }
    }
}
