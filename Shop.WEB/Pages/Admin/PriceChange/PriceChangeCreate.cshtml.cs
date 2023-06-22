using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopApi.Client;
using ShopDAL.Models;

namespace Shop.WEB.Pages.Admin.PriceChange
{
    public class PriceChangeCreateModel : PageModel
    {
        private readonly ILogger<PriceChangeCreateModel> _logger;
        private readonly Client client;
        public List<SelectListItem> Products { get; set; }
        public List<string> ValidationErrors { get; set; }
        private readonly IWebHostEnvironment _env;

        private readonly string _version;

        public PriceChangeCreateModel(ILogger<PriceChangeCreateModel> logger, Client client, IWebHostEnvironment env)
        {
            _logger = logger;
            this.client = client;
            _env = env;
            Products = new List<SelectListItem>();
            _version = "1.0";
        }

        public async Task OnGet()
        {
            var products = await client.GetAllProductAsync(_version);

            Products = products.Products
                .Select(o => new SelectListItem
                {
                    Value = o.Id.ToString(),
                    Text = o.Name
                })
                .ToList();
        }

        public async Task<IActionResult> OnPost(ChangesDetailsCreateDto[] changesDetails)
        {
            await OnGet();

            var ChangesDetails = changesDetails.Where(x => x.NewPrice > 0).ToList();

            if (!ChangesDetails.Any())
            {
                ModelState.AddModelError("", "Incorrect product price");
                ValidationErrors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return Page();
            }

            var PriceChange = new CreatePriceChangeDto
            {
                ChangeDetailsDto = ChangesDetails,
            };

            var result = await client.CreatePriceChangeAsync(_version, PriceChange);

            return Page();
        }

    }
}
