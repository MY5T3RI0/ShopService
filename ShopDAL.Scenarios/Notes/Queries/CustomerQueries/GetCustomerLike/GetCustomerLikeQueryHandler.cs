using AutoMapper;
using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductLike
{
    public class GetCustomerLikeQueryHandler : IRequestHandler<GetCustomerLikeQuery, CustomerLikeVm>
    {
        public IRepoService<Customer> _service;
        private readonly IMapper _mapper;

        public GetCustomerLikeQueryHandler(IRepoService<Customer> service, IMapper mapper)
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

        public async Task<CustomerLikeVm> Handle(GetCustomerLikeQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var categories = await _service.SearchAsync(nameof(Customer.Name), request.SearchString);

            if (categories == null)
                throw new NotFoundException(nameof(Customer), request.SearchString);

            var categoriesQuery = categories.Select(_mapper.Map<CustomerLikeLookupDto>).ToList();

            return new CustomerLikeVm { Customers = categoriesQuery };
        }
    }
}
