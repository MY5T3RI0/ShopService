using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct;
using ShopDAL.Scenarios.Notes.Queries.DeliveryQueries.GetDeliveryRelatedList.relatedDto;

namespace ShopAPI.Models
{
    public class CreateDeliveryDto : IMapWith<CreateDeliveryCommand>
    {
        public int StoreId { get; set; }
        public List<DeliveryInfoCreateDto> DeliveryInfoDto { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDeliveryDto, CreateDeliveryCommand>()
                .ForMember(deliveryDto => deliveryDto.StoreId,
                opt => opt.MapFrom(deliveryDto => deliveryDto.StoreId))
                .ForMember(deliveryCommand => deliveryCommand.DeliveryInfos,
                opt => opt.MapFrom(deliveryDto => deliveryDto.DeliveryInfoDto));
        }
    }
}
