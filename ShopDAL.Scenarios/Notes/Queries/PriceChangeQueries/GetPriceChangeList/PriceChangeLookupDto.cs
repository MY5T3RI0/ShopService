using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;

namespace ShopDAL.Scenarios.Notes.Queries.PriceChangeQueries.GetPriceChangeList
{
    public class PriceChangeLookupDto : IMapWith<PriceChange>
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public void Mapping(Profile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            profile.CreateMap<PriceChange, PriceChangeLookupDto>()
                .ForMember(priceChangeVm => priceChangeVm.Date,
                opt => opt.MapFrom(priceChange => priceChange.DateOfChange))
                .ForMember(priceChangeVm => priceChangeVm.Id,
                opt => opt.MapFrom(priceChange => priceChange.Id));
        }
    }
}
