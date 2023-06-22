using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.WEB.Pages.Admin.Product;
using ShopApi.Client;
using System;

namespace Shop.WEB.Pages.Admin.Delivery
{
    public class StoreDetailsModel : PageModel
    {
        private readonly ILogger<StoreDetailsModel> _logger;
        private readonly Client client;

        public StoreRelatedDetailsVm Store { get; set; }


        private readonly string _version;

        public StoreDetailsModel(ILogger<StoreDetailsModel> logger, Client client)
        {
            _logger = logger;
            this.client = client;
            Store = new StoreRelatedDetailsVm();
            _version = "1.0";
        }

        public async Task OnGet(int id)
        {
            Store = await client.GetRelatedStoreAsync(id, _version);
        }
    }
}
