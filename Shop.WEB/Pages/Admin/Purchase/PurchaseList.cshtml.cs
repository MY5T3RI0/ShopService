using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopApi.Client;
using ShopDAL.Models;

namespace Shop.WEB.Pages.Admin.Purchase
{
    public class PurchaseListModel : PageModel
    {
        private readonly ILogger<PurchaseListModel> _logger;
        private readonly Client client;
        public ICollection<PurchaseRelatedLookupDto> Purchases { get; private set; }

        public PurchaseListModel(ILogger<PurchaseListModel> logger, Client client)
        {
            _logger = logger;
            this.client = client;
            Purchases = new List<PurchaseRelatedLookupDto>();
        }

        public async Task OnGet()
        {
            var deliveries = await client.GetAllRelatedPurchaseAsync("1.0");
            Purchases = deliveries.Purchases;

        }
    }
}
