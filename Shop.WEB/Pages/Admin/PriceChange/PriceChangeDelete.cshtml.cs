using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.WEB.Pages.Admin.Delivery;
using ShopApi.Client;

namespace Shop.WEB.Pages.Admin.PriceChange
{
    public class PriceChangeDeleteModel : PageModel
    {
        private readonly ILogger<PriceChangeDeleteModel> _logger;
        private readonly Client client;
        private readonly string _version;
        public PriceChangeDetailsVm PriceChange { get; set; }

        public PriceChangeDeleteModel(ILogger<PriceChangeDeleteModel> logger, Client client)
        {
            _logger = logger;
            this.client = client;
            _version = "1.0";
        }

        public async Task OnGet(int id)
        {
            PriceChange = await client.GetPriceChangeAsync(id, _version);
        }

        public async Task<IActionResult> OnPost(PriceChangeDetailsVm PriceChange)
        {
            await client.DeletePriceChangeAsync(PriceChange.Id, _version);

            return RedirectToPage("/Admin/PriceChange/PriceChangeList");
        }
    }
}


