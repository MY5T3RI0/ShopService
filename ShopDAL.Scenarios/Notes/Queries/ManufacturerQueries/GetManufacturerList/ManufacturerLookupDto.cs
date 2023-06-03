using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductList
{
    public class ManufacturerLookupDto : IMapWith<Manufacturer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            profile.CreateMap<Manufacturer, ManufacturerLookupDto>()
                .ForMember(manufacturerVm => manufacturerVm.Name,
                opt => opt.MapFrom(manufacturer => manufacturer.Name))
                .ForMember(manufacturerVm => manufacturerVm.Id,
                opt => opt.MapFrom(manufacturer => manufacturer.Id));
        }
    }
}
