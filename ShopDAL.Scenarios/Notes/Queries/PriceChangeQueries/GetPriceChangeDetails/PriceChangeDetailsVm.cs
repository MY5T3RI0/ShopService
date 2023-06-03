using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;

namespace ShopDAL.Scenarios.Notes.Queries.PriceChangeQueries.GetPriceChangeDetails
{
    public class PriceChangeDetailsVm : IMapWith<PriceChange>
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }

        public void Mapping(Profile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            profile.CreateMap<PriceChange, PriceChangeDetailsVm>()
                .ForMember(priceChangeVm => priceChangeVm.Id,
                opt => opt.MapFrom(priceChange => priceChange.Id))
                .ForMember(priceChangeVm => priceChangeVm.Date,
                opt => opt.MapFrom(priceChange => priceChange.DateOfChange));
        }
    }
}
