using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductRelatedList.relatedDto;

namespace ShopDAL.Scenarios.Notes.Queries.PriceChangeQueries.GetPriceChangeDetails
{
    public class PriceChangeRelatedDetailsVm : IMapWith<PriceChange>
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public List<PriceChangeChangesDetailsDto> ChangesDetails { get; set; }

        public void Mapping(Profile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            profile.CreateMap<PriceChange, PriceChangeRelatedDetailsVm>()
                .ForMember(priceChangeVm => priceChangeVm.Date,
                opt => opt.MapFrom(priceChange => priceChange.DateOfChange))
                .ForMember(priceChangeVm => priceChangeVm.Id,
                opt => opt.MapFrom(priceChange => priceChange.Id));
        }
    }
}
