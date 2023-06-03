using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct;
using ShopDAL.Scenarios.Notes.Queries.DeliveryQueries.GetDeliveryRelatedList.relatedDto;

namespace ShopAPI.Models
{
    public class UpdateDeliveryDto : IMapWith<UpdateDeliveryCommand>
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public DateOnly Date { get; set; }
        public List<DeliveryInfoCreateDto> DeliveryInfoDto { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateDeliveryDto, UpdateDeliveryCommand>()
                .ForMember(deliveryDto => deliveryDto.Id,
                opt => opt.MapFrom(deliveryDto => deliveryDto.Id))
                .ForMember(deliveryDto => deliveryDto.StoreId,
                opt => opt.MapFrom(deliveryDto => deliveryDto.StoreId))
                .ForMember(deliveryDto => deliveryDto.Date,
                opt => opt.MapFrom(deliveryDto => deliveryDto.Date))
                .ForMember(deliveryDto => deliveryDto.DeliveryInfos,
                opt => opt.MapFrom(deliveryDto => deliveryDto.DeliveryInfoDto));
        }
    }
}
