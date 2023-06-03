using AutoMapper;
using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductRelated;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductDetails
{
    public class GetProductRelatedDetailsQueryHandler : IRequestHandler<GetProductRelatedDetailsQuery, ProductRelatedDetailsVm>
    {
        private readonly IRepoService<Product> _service;
        private readonly IMapper _mapper;

        public GetProductRelatedDetailsQueryHandler(IRepoService<Product> service, IMapper mapper)
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

        public async Task<ProductRelatedDetailsVm> Handle(GetProductRelatedDetailsQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = await _service.GetRelatedDataAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Product), request.Id);

            return _mapper.Map<ProductRelatedDetailsVm>(entity);
        }
    }
}
