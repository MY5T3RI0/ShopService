using AutoMapper;
using ShopDAL.Scenarios.Common.Mappings;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductRelatedList.relatedDto;

namespace ShopAPI.Models
{
    public class CreatePurchaseDto : IMapWith<CreatePurchaseCommand>
    {
        public int CustomerId { get; set; }
        public List<StoreProductCreateDto> StoreProducts { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePurchaseDto, CreatePurchaseCommand>()
                .ForMember(deliveryCommand => deliveryCommand.CustomerId,
                opt => opt.MapFrom(deliveryDto => deliveryDto.CustomerId))
                .ForMember(deliveryCommand => deliveryCommand.StoreProducts,
                opt => opt.MapFrom(deliveryDto => deliveryDto.StoreProducts));
        }
    }
}
