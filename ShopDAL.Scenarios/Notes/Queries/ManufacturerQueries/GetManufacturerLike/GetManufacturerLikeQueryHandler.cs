using AutoMapper;
using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductLike
{
    public class GetManufacturerLikeQueryHandler : IRequestHandler<GetManufacturerLikeQuery, ManufacturerLikeVm>
    {
        public IRepoService<Manufacturer> _service;
        private readonly IMapper _mapper;

        public GetManufacturerLikeQueryHandler(IRepoService<Manufacturer> service, IMapper mapper)
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

        public async Task<ManufacturerLikeVm> Handle(GetManufacturerLikeQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var categories = await _service.SearchAsync(nameof(Manufacturer.Name), request.SearchString);

            if (categories == null)
                throw new NotFoundException(nameof(Manufacturer), request.SearchString);

            var categoriesQuery = categories.Select(_mapper.Map<ManufacturerLikeLookupDto>).ToList();

            return new ManufacturerLikeVm { Manufacturers = categoriesQuery };
        }
    }
}
