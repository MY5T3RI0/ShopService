using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.WEB.Pages.Admin.Delivery;
using ShopApi.Client;

namespace Shop.WEB.Pages.Admin.Store
{
    public class StoreDeleteModel : PageModel
    {
        private readonly ILogger<StoreDeleteModel> _logger;
        private readonly Client client;
        private readonly string _version;
        public StoreDetailsVm Store { get; set; }

        public StoreDeleteModel(ILogger<StoreDeleteModel> logger, Client client)
        {
            _logger = logger;
            this.client = client;
            _version = "1.0";
        }

        public async Task OnGet(int id)
        {
            Store = await client.GetStoreAsync(id, _version);
        }

        public async Task<IActionResult> OnPost(StoreDetailsVm Store)
        {
            await client.DeleteStoreAsync(Store.Id, _version);

            return RedirectToPage("/Admin/Store/StoreList");
        }
    }
}


