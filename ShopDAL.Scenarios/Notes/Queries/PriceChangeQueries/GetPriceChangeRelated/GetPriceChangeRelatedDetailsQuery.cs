using MediatR;
using ShopDAL.Scenarios.Notes.Queries.PriceChangeQueries.GetPriceChangeDetails;
using ShopDAL.Scenarios.Notes.Queries.PriceChangeQueries.GetPriceChangeRelatedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDAL.Scenarios.Notes.Queries.PriceChangeQueries.GetPriceChangeRelated
{
    public class GetPriceChangeRelatedDetailsQuery : IRequest<PriceChangeRelatedDetailsVm>
    {
        public int Id { get; set; }
    }
}
