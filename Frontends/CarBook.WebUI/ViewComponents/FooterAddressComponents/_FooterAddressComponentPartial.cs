using CarBook.Dto.FooterAddress;
using CarBook.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.FooterAddressComponents
{
    public class _FooterAddressComponentPartial:ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public _FooterAddressComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7192/api/FooterAddresses");
            if (responseMessage.IsSuccessStatusCode)
            {
                var dataJson = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFooterAddressDto>>(dataJson);
                return View(values);
            }
            return View();
        }


    }
}
