using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.WEB.Pages.Admin.Product;
using ShopApi.Client;

namespace Shop.WEB.Pages.Admin.PriceChange
{
    public class PriceChangeListModel : PageModel
    {
        private readonly ILogger<PriceChangeListModel> _logger;
        private readonly Client client;
        public ICollection<PriceChangeRelatedLookupDto> PriceChanges { get; private set; }

        public PriceChangeListModel(ILogger<PriceChangeListModel> logger, Client client)
        {
            _logger = logger;
            this.client = client;
            PriceChanges = new List<PriceChangeRelatedLookupDto>();
        }

        public async Task OnGet()
        {
            var priceChange = await client.GetAllRelatedPriceChangeAsync("1.0");
            PriceChanges = priceChange.PriceChanges;

        }
    }
}
