using AutoMapper;
using ShopDAL.Scenarios.Common.Mappings;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct;

namespace ShopAPI.Models
{
    public class CreateCustomerDto : IMapWith<CreateCustomerCommand>
    {
        public string? Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCustomerDto, CreateCustomerCommand>()
                .ForMember(customerCommand => customerCommand.Name,
                opt => opt.MapFrom(customerDto => customerDto.Name));
        }
    }
}
