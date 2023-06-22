using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.WEB.Pages.Admin.Product;
using ShopApi.Client;
using System;

namespace Shop.WEB.Pages.Admin.Delivery
{
    public class DeliveryListModel : PageModel
    {
        private readonly ILogger<DeliveryListModel> _logger;
        private readonly Client client;
        public ICollection<DeliveryRelatedLookupDto> Deliveries { get; private set; }

        private readonly string _version;

        public DeliveryListModel(ILogger<DeliveryListModel> logger, Client client)
        {
            _logger = logger;
            this.client = client;
            Deliveries = new List<DeliveryRelatedLookupDto>();
            _version = "1.0";
        }

        public async Task OnGet()
        {
            var deliveries = await client.GetAllRelatedDeliveryAsync(_version);
            Deliveries = deliveries.Deliveries;

        }
    }
}
