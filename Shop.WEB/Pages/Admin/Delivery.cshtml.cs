using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopApi.Client;

namespace Shop.WEB.Pages
{
    public class DeliveryModel : PageModel
    {
        private readonly ILogger<ProductsModel> _logger;
        private readonly Client client;
        public ICollection<DeliveryRelatedLookupDto> Deliveries { get; private set; }

        public DeliveryModel(ILogger<ProductsModel> logger, Client client)
        {
            _logger = logger;
            this.client = client;
            Deliveries = new List<DeliveryRelatedLookupDto>();
        }

        public async Task OnGet()
        {
            var deliveries = await client.GetAllRelatedDeliveryAsync("1.0");
            Deliveries = deliveries.Deliveries;

        }
    }
}
