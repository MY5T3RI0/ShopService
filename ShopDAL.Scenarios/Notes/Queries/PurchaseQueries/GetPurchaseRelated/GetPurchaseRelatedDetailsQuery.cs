using MediatR;
using ShopDAL.Scenarios.Notes.Queries.PurchaseQueries.GetPurchaseDetails;
using ShopDAL.Scenarios.Notes.Queries.PurchaseQueries.GetPurchaseRelatedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDAL.Scenarios.Notes.Queries.PurchaseQueries.GetPurchaseRelated
{
    public class GetPurchaseRelatedDetailsQuery : IRequest<PurchaseRelatedDetailsVm>
    {
        public int Id { get; set; }
    }
}
