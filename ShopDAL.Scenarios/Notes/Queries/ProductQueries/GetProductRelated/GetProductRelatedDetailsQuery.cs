using MediatR;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductDetails;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductRelatedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductRelated
{
    public class GetProductRelatedDetailsQuery : IRequest<ProductRelatedDetailsVm>
    {
        public int Id { get; set; }
    }
}
