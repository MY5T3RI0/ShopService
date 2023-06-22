using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.WEB.Pages.Admin.Product;
using ShopApi.Client;
using System;

namespace Shop.WEB.Pages.Admin.Delivery
{
    public class PurchaseDetailsModel : PageModel
    {
        private readonly ILogger<PurchaseDetailsModel> _logger;
        private readonly Client client;
        public PurchaseRelatedDetailsVm Purchase { get; private set; }

        private readonly string _version;

        public PurchaseDetailsModel(ILogger<PurchaseDetailsModel> logger, Client client)
        {
            _logger = logger;
            this.client = client;
            Purchase = new PurchaseRelatedDetailsVm();
            _version = "1.0";
        }

        public async Task OnGet(int id)
        {
            Purchase = await client.GetRelatedPurchaseAsync(id, _version);
        }
    }
}
