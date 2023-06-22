using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.WEB.Pages.Admin.Delivery;
using ShopApi.Client;

namespace Shop.WEB.Pages.Admin.Manufacturer
{
    public class ManufacturerDeleteModel : PageModel
    {
        private readonly ILogger<ManufacturerDeleteModel> _logger;
        private readonly Client client;
        private readonly string _version;
        public ManufacturerDetailsVm Manufacturer { get; set; }

        public ManufacturerDeleteModel(ILogger<ManufacturerDeleteModel> logger, Client client)
        {
            _logger = logger;
            this.client = client;
            _version = "1.0";
        }

        public async Task OnGet(int id)
        {
            Manufacturer = await client.GetManufacturerAsync(id, _version);
        }

        public async Task<IActionResult> OnPost(ManufacturerDetailsVm Manufacturer)
        {
            await client.DeleteManufacturerAsync(Manufacturer.Id, _version);

            return RedirectToPage("/Admin/Manufacturer/ManufacturerList");
        }
    }
}


