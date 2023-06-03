using AutoMapper;
using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Queries.StoreQueries.GetStoreList
{
    public class GetStoreListQueryHandler : IRequestHandler<GetStoreListQuery, StoreListVm>
    {
        private readonly IRepoService<Store> _service;
        private readonly IMapper _mapper;

        public GetStoreListQueryHandler(IRepoService<Store> service,
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

        public async Task<StoreListVm> Handle(GetStoreListQuery request,
            CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entities = await _service.GetAllAsync();

            if (entities == null)
                throw new NotFoundException(nameof(Store), request);

            var entitiesQuery = entities.Select(_mapper.Map<StoreLookupDto>).ToList();

            return new StoreListVm { Stores = entitiesQuery };
        }
    }
}
