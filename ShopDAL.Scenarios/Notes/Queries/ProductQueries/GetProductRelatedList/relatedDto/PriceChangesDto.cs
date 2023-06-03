using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductRelatedList.relatedDto
{
    public class PriceChangesDto : IMapWith<PriceChange>
    {
        public DateOnly DateOfChange { get; set; }

        public List<ProductChangesDetailsDto> ChangesDetails { get; set; }

        public void Mapping(Profile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            profile.CreateMap<PriceChange, PriceChangesDto>()
                .ForMember(productVm => productVm.DateOfChange,
                opt => opt.MapFrom(product => product.DateOfChange))
                .ForMember(productVm => productVm.ChangesDetails,
                opt => opt.MapFrom(product => product.ChangesDetails));
        }
    }
}
