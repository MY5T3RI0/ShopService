using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductDetails
{
    public class CustomerDetailsVm : IMapWith<Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            profile.CreateMap<Customer, CustomerDetailsVm>()
                .ForMember(customerCommand => customerCommand.Name,
                opt => opt.MapFrom(customerDto => customerDto.Name))
                .ForMember(customerCommand => customerCommand.Id,
                opt => opt.MapFrom(customerDto => customerDto.Id));
        }
    }
}
