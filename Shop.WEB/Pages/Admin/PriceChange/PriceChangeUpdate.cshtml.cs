using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopApi.Client;

namespace Shop.WEB.Pages.Admin.PriceChange
{
    public class PriceChangeUpdateModel : PageModel
    {
        private readonly ILogger<PriceChangeUpdateModel> _logger;
        private readonly Client client;
        public List<SelectListItem> Products { get; set; }
        public List<string> ValidationErrors { get; set; }

        public PriceChangeRelatedDetailsVm PriceChange { get; set; }

        private readonly IWebHostEnvironment _env;

        private readonly string _version;

        public PriceChangeUpdateModel(ILogger<PriceChangeUpdateModel> logger, Client client, IWebHostEnvironment env)
        {
            _logger = logger;
            this.client = client;
            _env = env;
            Products = new List<SelectListItem>();
            PriceChange = new PriceChangeRelatedDetailsVm();
            _version = "1.0";
        }

        public async Task<IActionResult> OnGet(int id)
        {
            PriceChange = await client.GetRelatedPriceChangeAsync(id, _version);

            var products = await client.GetAllProductAsync(_version);

            Products = products.Products
                .Select(o => new SelectListItem
                {
                    Value = o.Id.ToString(),
                    Text = o.Name
                })
                .ToList();

            return Page();
        }

        public async Task<IActionResult> OnPost(ChangesDetailsCreateDto[] _changesDetails, PriceChangeRelatedDetailsVm priceChange)
        {
            await OnGet(priceChange.Id);

            var ChangesDetails = _changesDetails.Where(x => x.NewPrice > 0).ToList();

            var newId = priceChange.Id;

            if (!ChangesDetails.Any())
                ModelState.AddModelError("", "Incorrect product price");
            else
            {
                var PriceChange = new UpdatePriceChangeDto
                {
                    Id = priceChange.Id,
                    ChangeDetails = ChangesDetails,
                    Date = priceChange.Date,
                };

                try
                {
                    newId = await client.UpdatePriceChangeAsync(_version, PriceChange);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            if (!ModelState.IsValid)
            {
                ValidationErrors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return await OnGet(priceChange.Id);
            }

            return RedirectToPage("/Admin/PriceChange/PriceChangeList");
        }

    }
}
