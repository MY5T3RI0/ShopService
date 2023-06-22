using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.WEB.Pages.Admin.Product;
using ShopApi.Client;

namespace Shop.WEB.Pages.Admin.Manufacturer
{
    public class ManufacturerListModel : PageModel
    {
        private readonly ILogger<ManufacturerListModel> _logger;
        private readonly Client client;
        private readonly string _version;

        public ICollection<ManufacturerLookupDto> Manufacturers { get; private set; }
        public List<string> ValidationErrors { get; set; }

        public ManufacturerListModel(ILogger<ManufacturerListModel> logger, Client client)
        {
            _logger = logger;
            this.client = client;
            Manufacturers = new List<ManufacturerLookupDto>();
            _version = "1.0";
        }

        public async Task OnGet()
        {
            var Manufacturer = await client.GetAllManufacturerAsync(_version);
            Manufacturers = Manufacturer.Manufacturers;
        }
        public async Task OnPost(int id, string name)
        {

            if (!ModelState.IsValid)
            {
                ValidationErrors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var _manufacturer = new UpdateManufacturerDto
                {
                    Id = id,
                    Name = name
                };
                await client.UpdateManufacturerAsync(_version, _manufacturer);
            }

            await OnGet();
        }
    }
}
