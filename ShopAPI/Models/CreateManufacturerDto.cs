using AutoMapper;
using ShopDAL.Scenarios.Common.Mappings;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct;

namespace ShopAPI.Models
{
    public class CreateManufacturerDto : IMapWith<CreateManufacturerCommand>
    {
        public string? Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateManufacturerDto, CreateManufacturerCommand>()
                .ForMember(customerCommand => customerCommand.Name,
                opt => opt.MapFrom(customerDto => customerDto.Name));
        }
    }
}
