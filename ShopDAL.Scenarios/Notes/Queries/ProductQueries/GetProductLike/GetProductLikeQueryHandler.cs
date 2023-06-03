using AutoMapper;
using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;
using System.Reflection;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductLike
{
    public class GetProductLikeQueryHandler : IRequestHandler<GetProductLikeQuery, ProductLikeVm>
    {
        public IRepoService<Product> _service;
        private readonly IMapper _mapper;

        public GetProductLikeQueryHandler(IRepoService<Product> service, IMapper mapper)
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

        public async Task<ProductLikeVm> Handle(GetProductLikeQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var products = await _service.SearchAsync(nameof(Product.Name), request.SearchString);

            if (products == null)
                throw new NotFoundException(nameof(Product), request.SearchString);

            var productsQuery = products.Select(_mapper.Map<ProductLikeLookupDto>).ToList();

            return new ProductLikeVm { Products = productsQuery };
        }
    }
}
