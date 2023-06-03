using AutoMapper;
using ShopDAL.Scenarios.Common.Mappings;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct;

namespace ShopAPI.Models
{
    public class UpdateManufacturerDto : IMapWith<UpdateManufacturerCommand>
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateManufacturerDto, UpdateManufacturerCommand>()
                .ForMember(productCommand => productCommand.Name,
                opt => opt.MapFrom(productDto => productDto.Name))
                .ForMember(productCommand => productCommand.Id,
                opt => opt.MapFrom(productDto => productDto.Id));
        }
    }
}
