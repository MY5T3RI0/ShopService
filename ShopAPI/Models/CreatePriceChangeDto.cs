using AutoMapper;
using ShopDAL.Scenarios.Common.Mappings;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductRelatedList.relatedDto;

namespace ShopAPI.Models
{
    public class CreatePriceChangeDto : IMapWith<CreatePriceChangeCommand>
    {
        public List<ChangesDetailsCreateDto> ChangeDetailsDto { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePriceChangeDto, CreatePriceChangeCommand>()
                .ForMember(deliveryCommand => deliveryCommand.ChangeDetails,
                opt => opt.MapFrom(deliveryDto => deliveryDto.ChangeDetailsDto));
        }
    }
}
