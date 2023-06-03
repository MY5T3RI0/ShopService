using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct;
using ShopDAL.Scenarios.Notes.Queries.DeliveryQueries.GetDeliveryRelatedList.relatedDto;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductRelatedList.relatedDto;

namespace ShopAPI.Models
{
    public class UpdatePurchaseDto : IMapWith<UpdatePurchaseCommand>
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public int CustomerId { get; set; }

        public List<StoreProductCreateDto> StoreProduct { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePurchaseDto, UpdatePurchaseCommand>()
            .ForMember(deliveryCommand => deliveryCommand.StoreProducts,
                opt => opt.MapFrom(deliveryDto => deliveryDto.StoreProduct))
            .ForMember(deliveryCommand => deliveryCommand.CustomerId,
                opt => opt.MapFrom(deliveryDto => deliveryDto.CustomerId))
            .ForMember(deliveryCommand => deliveryCommand.Date,
                opt => opt.MapFrom(deliveryDto => deliveryDto.Date))
            .ForMember(deliveryCommand => deliveryCommand.Id,
                opt => opt.MapFrom(deliveryDto => deliveryDto.Id));
        }
    }
}
