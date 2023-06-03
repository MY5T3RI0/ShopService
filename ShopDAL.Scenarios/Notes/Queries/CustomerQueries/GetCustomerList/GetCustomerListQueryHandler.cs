using AutoMapper;
using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductList
{
    public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, CustomerListVm>
    {
        private readonly IRepoService<Customer> _service;
        private readonly IMapper _mapper;

        public GetCustomerListQueryHandler(IRepoService<Customer> service,
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

        public async Task<CustomerListVm> Handle(GetCustomerListQuery request,
            CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var categories = await _service.GetAllAsync();

            if (categories == null)
                throw new NotFoundException(nameof(Customer), request);

            var categoriesQuery = categories.Select(_mapper.Map<CustomerLookupDto>).ToList();

            return new CustomerListVm { Customers = categoriesQuery };
        }
    }
}
