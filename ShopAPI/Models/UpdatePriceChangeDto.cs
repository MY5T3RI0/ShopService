using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct;
using ShopDAL.Scenarios.Notes.Queries.DeliveryQueries.GetDeliveryRelatedList.relatedDto;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductRelatedList.relatedDto;

namespace ShopAPI.Models
{
    public class UpdatePriceChangeDto : IMapWith<UpdatePriceChangeCommand>
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }

        public List<ChangesDetailsCreateDto> ChangeDetails { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePriceChangeDto, UpdatePriceChangeCommand>()
            .ForMember(deliveryCommand => deliveryCommand.ChangesDetails,
                opt => opt.MapFrom(deliveryDto => deliveryDto.ChangeDetails))
            .ForMember(deliveryCommand => deliveryCommand.Date,
                opt => opt.MapFrom(deliveryDto => deliveryDto.Date))
            .ForMember(deliveryCommand => deliveryCommand.Id,
                opt => opt.MapFrom(deliveryDto => deliveryDto.Id));
        }
    }
}
