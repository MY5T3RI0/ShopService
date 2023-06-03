using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductRelatedList.relatedDto
{
    public class PriceChangeChangesDetailsDto : IMapWith<ChangesDetails>
    {
        public int ProductId { get; set; }
        public decimal NewPrice { get; set; }

        public void Mapping(Profile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            profile.CreateMap<ChangesDetails, PriceChangeChangesDetailsDto>()
                .ForMember(productVm => productVm.ProductId,
                opt => opt.MapFrom(product => product.ProductId))
                .ForMember(productVm => productVm.NewPrice,
                opt => opt.MapFrom(product => product.NewPrice));
        }
    }
}
