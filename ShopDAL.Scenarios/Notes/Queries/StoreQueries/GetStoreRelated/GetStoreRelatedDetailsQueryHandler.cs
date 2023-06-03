using AutoMapper;
using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;
using ShopDAL.Scenarios.Notes.Queries.StoreQueries.GetStoreRelated;

namespace ShopDAL.Scenarios.Notes.Queries.StoreQueries.GetStoreDetails
{
    public class GetStoreRelatedDetailsQueryHandler : IRequestHandler<GetStoreRelatedDetailsQuery, StoreRelatedDetailsVm>
    {
        private readonly IRepoService<Store> _service;
        private readonly IMapper _mapper;

        public GetStoreRelatedDetailsQueryHandler(IRepoService<Store> service, IMapper mapper)
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

        public async Task<StoreRelatedDetailsVm> Handle(GetStoreRelatedDetailsQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = await _service.GetRelatedDataAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Store), request.Id);

            return _mapper.Map<StoreRelatedDetailsVm>(entity);
        }
    }
}
