using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.WEB.Pages.Admin.Delivery;
using ShopApi.Client;

namespace Shop.WEB.Pages.Admin.Purchase
{
    public class PurchaseDeleteModel : PageModel
    {
        private readonly ILogger<PurchaseDeleteModel> _logger;
        private readonly Client client;
        private readonly string _version;
        public PurchaseRelatedDetailsVm Purchase { get; set; }

        public PurchaseDeleteModel(ILogger<PurchaseDeleteModel> logger, Client client)
        {
            _logger = logger;
            this.client = client;
            _version = "1.0";
        }

        public async Task OnGet(int id)
        {
            Purchase = await client.GetRelatedPurchaseAsync(id, _version);
        }

        public async Task<IActionResult> OnPost(PurchaseRelatedDetailsVm Purchase)
        {
            await client.DeletePurchaseAsync(Purchase.Id, _version);

            return RedirectToPage("/Admin/Purchase/PurchaseList");
        }
    }
}


