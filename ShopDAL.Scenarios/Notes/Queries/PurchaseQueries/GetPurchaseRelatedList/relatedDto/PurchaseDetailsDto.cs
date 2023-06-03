using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductRelatedList.relatedDto
{
    public class PurchaseDetailsDto : IMapWith<PurchaseDetails>
    {
        public int ProductId { get; set; }
        public int ProductCount{ get; set; }
        public int Discount{ get; set; }

        public void Mapping(Profile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            profile.CreateMap<PurchaseDetails, PurchaseDetailsDto>()
                .ForMember(productVm => productVm.ProductId,
                opt => opt.MapFrom(product => product.ProductId))
                .ForMember(productVm => productVm.Discount,
                opt => opt.MapFrom(product => product.Discount))
                .ForMember(productVm => productVm.ProductCount,
                opt => opt.MapFrom(product => product.ProductCount));
        }
    }
}
