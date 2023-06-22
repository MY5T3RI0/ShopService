using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopApi.Client;
using System.ComponentModel;

namespace Shop.WEB.Pages.Admin.Delivery
{
    public class DeliveryCreateModel : PageModel
    {
        private readonly ILogger<DeliveryCreateModel> _logger;
        private readonly Client client;
        public List<SelectListItem> Products { get; set; }
        public List<SelectListItem> Stores { get; set; }
        public List<string> ValidationErrors { get; set; }

        private readonly IWebHostEnvironment _env;

        private readonly string _version;

        public DeliveryCreateModel(ILogger<DeliveryCreateModel> logger, Client client, IWebHostEnvironment env)
        {
            _logger = logger;
            this.client = client;
            _env = env;
            Products = new List<SelectListItem>();
            Stores = new List<SelectListItem>();
            _version = "1.0";
        }

        public async Task OnGet()
        {
            var products = await client.GetAllProductAsync(_version);
            var stores = await client.GetAllStoreAsync(_version);

            Products = products.Products
                .Select(o => new SelectListItem
                {
                    Value = o.Id.ToString(),
                    Text = o.Name
                })
                .ToList();

            Stores = stores.Stores
                .Select(o => new SelectListItem
                {
                    Value = o.Id.ToString(),
                    Text = o.Name
                })
                .ToList();
        }

        public async Task<IActionResult> OnPost(int storeId, DeliveryInfoCreateDto[] DeliveryInfos)
        {
            await OnGet();

            var deliveryInfos = DeliveryInfos.Where(x => x.ProductCount > 0).ToList();
            if (!deliveryInfos.Any()) 
            {
                ModelState.AddModelError("", "Incorrect product count");
                ValidationErrors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return Page();
            }

            var Delivery = new CreateDeliveryDto
            {
                StoreId = storeId,
                DeliveryInfoDto = deliveryInfos
            };

            var result = await client.CreateDeliveryAsync(_version, Delivery);

            return Page();
        }

    }
}
