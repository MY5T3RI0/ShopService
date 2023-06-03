using AutoMapper;
using ShopDAL.Scenarios.Common.Mappings;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct;

namespace ShopAPI.Models
{
    public class CreateStoreDto : IMapWith<CreateStoreCommand>
    {
        public string? Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateStoreDto, CreateStoreCommand>()
                .ForMember(categoryCommand => categoryCommand.Name,
                opt => opt.MapFrom(categoryDto => categoryDto.Name));
        }
    }
}
