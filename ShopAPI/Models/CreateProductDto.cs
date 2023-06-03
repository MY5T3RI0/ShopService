using AutoMapper;
using ShopDAL.Scenarios.Common.Mappings;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct;

namespace ShopAPI.Models
{
    public class CreateProductDto : IMapWith<CreateProductCommand>
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProductDto, CreateProductCommand>()
                .ForMember(productCommand => productCommand.Name,
                opt => opt.MapFrom(productDto => productDto.Name))
                .ForMember(productCommand => productCommand.Price,
                opt => opt.MapFrom(productDto => productDto.Price))
            .ForMember(productCommand => productCommand.CategoryId,
                opt => opt.MapFrom(productDto => productDto.CategoryId))
                .ForMember(productCommand => productCommand.ManufacturerId,
                opt => opt.MapFrom(productDto => productDto.ManufacturerId));
        }
    }
}
