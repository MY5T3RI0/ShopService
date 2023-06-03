using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;

namespace ShopDAL.Scenarios.Notes.Queries.StoreQueries.GetStoreDetails
{
    public class StoreDetailsVm : IMapWith<Store>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            profile.CreateMap<Store, StoreDetailsVm>()
                .ForMember(storeVm => storeVm.Id,
                opt => opt.MapFrom(store => store.Id))
                .ForMember(storeVm => storeVm.Name,
                opt => opt.MapFrom(store => store.Name));
        }
    }
}
