using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductRelatedList.relatedDto
{
    public class PurchaseDto : IMapWith<Purchase>
    {
        public DateOnly Date { get; set; }
        public Customer Customer { get; set; }
        public int Id{ get; set; }

        public void Mapping(Profile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            profile.CreateMap<Purchase, PurchaseDto>()
                .ForMember(productVm => productVm.Id,
                opt => opt.MapFrom(product => product.Id))
                .ForMember(productVm => productVm.Date,
                opt => opt.MapFrom(product => product.Date))
                .ForMember(productVm => productVm.Customer,
                opt => opt.MapFrom(product => product.Customer));
        }
    }
}
