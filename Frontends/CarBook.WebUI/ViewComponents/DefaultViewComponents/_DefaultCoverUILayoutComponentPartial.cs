using CarBook.Dto.BannerDtos;
using CarBook.Dto.FooterAddress;
using CarBook.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultCoverUILayoutComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultCoverUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7192/api/Banners");
            if (responseMessage.IsSuccessStatusCode)
            {
                var dataJson = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBannerDto>>(dataJson);
                return View(values);
            }
            return View();
        }

    }
}
