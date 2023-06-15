using AutoMapper;
using ShopDAL.Scenarios.Common.Mappings;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct;

namespace ShopAPI.Models
{
    public class UpdateProductDto : IMapWith<UpdateProductCommand>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Decimal Price { get; set; }
        public int ManufacturerId { get; set; }
        public int CategoryId { get; set; }
        public string? ImageName { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProductDto, UpdateProductCommand>()
                .ForMember(productCommand => productCommand.Name,
                opt => opt.MapFrom(productDto => productDto.Name))
                .ForMember(productCommand => productCommand.ImageName,
                opt => opt.MapFrom(productDto => productDto.ImageName))
                .ForMember(productCommand => productCommand.Price,
                opt => opt.MapFrom(productDto => productDto.Price))
                .ForMember(productCommand => productCommand.Id,
                opt => opt.MapFrom(productDto => productDto.Id))
                .ForMember(productCommand => productCommand.CategoryId,
                opt => opt.MapFrom(productDto => productDto.CategoryId))
                .ForMember(productCommand => productCommand.ManufacturerId,
                opt => opt.MapFrom(productDto => productDto.ManufacturerId));
        }
    }
}
