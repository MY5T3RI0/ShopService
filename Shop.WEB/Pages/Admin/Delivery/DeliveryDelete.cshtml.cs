using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.WEB.Pages.Admin.Delivery;
using ShopApi.Client;

namespace Shop.WEB.Pages.Admin.Delivery
{
    public class DeliveryDeleteModel : PageModel
    {
        private readonly ILogger<DeliveryDeleteModel> _logger;
        private readonly Client client;
        private readonly string _version;
        public DeliveryRelatedDetailsVm Delivery { get; set; }

        public DeliveryDeleteModel(ILogger<DeliveryDeleteModel> logger, Client client)
        {
            _logger = logger;
            this.client = client;
            _version = "1.0";
        }

        public async Task OnGet(int id)
        {
            Delivery = await client.GetRelatedDeliveryAsync(id, _version);
        }

        public async Task<IActionResult> OnPost(DeliveryRelatedDetailsVm Delivery)
        {
            await client.DeleteDeliveryAsync(Delivery.Id, _version);

            return RedirectToPage("/Admin/Delivery/DeliveryList");
        }
    }
}


