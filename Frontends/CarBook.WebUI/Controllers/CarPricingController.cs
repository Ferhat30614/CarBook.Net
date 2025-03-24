using CarBook.Dto.BlogDtos;
using CarBook.Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.WebUI.Controllers
{
    public class CarPricingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarPricingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Paketler";
            ViewBag.v2 = "Araç Fiyat Paketleri";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7192/api/CarPricings/CarPricingWithTimePeriodList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var dataJson = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingListWithModelDto>>(dataJson);
                return View(values);
            }
            return View();
        }
            
    }
}
