using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductRelatedList.relatedDto
{
    public class ProductChangesDetailsDto : IMapWith<ChangesDetails>
    {
        public int ProductId { get; set; }
        public decimal NewPrice { get; set; }

        public void Mapping(Profile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            profile.CreateMap<ChangesDetails, ProductChangesDetailsDto>()
                .ForMember(productVm => productVm.ProductId,
                opt => opt.MapFrom(product => product.ProductId))
                .ForMember(productVm => productVm.NewPrice,
                opt => opt.MapFrom(product => product.NewPrice));
        }
    }
}
