using MediatR;
using ShopDAL.Scenarios.Notes.Queries.StoreQueries.GetStoreDetails;
using ShopDAL.Scenarios.Notes.Queries.StoreQueries.GetStoreRelatedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDAL.Scenarios.Notes.Queries.StoreQueries.GetStoreRelated
{
    public class GetStoreRelatedDetailsQuery : IRequest<StoreRelatedDetailsVm>
    {
        public int Id { get; set; }
    }
}
