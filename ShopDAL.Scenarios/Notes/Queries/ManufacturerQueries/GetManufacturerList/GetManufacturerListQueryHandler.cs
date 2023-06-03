using AutoMapper;
using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductList
{
    public class GetManufacturerListQueryHandler : IRequestHandler<GetManufacturerListQuery, ManufacturerListVm>
    {
        private readonly IRepoService<Manufacturer> _service;
        private readonly IMapper _mapper;

        public GetManufacturerListQueryHandler(IRepoService<Manufacturer> service,
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

        public async Task<ManufacturerListVm> Handle(GetManufacturerListQuery request,
            CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var categories = await _service.GetAllAsync();

            if (categories == null)
                throw new NotFoundException(nameof(Manufacturer), request);

            var categoriesQuery = categories.Select(_mapper.Map<ManufacturerLookupDto>).ToList();

            return new ManufacturerListVm { Manufacturers = categoriesQuery };
        }
    }
}
