using CarBook.Dto.CarDtos;
using CarBook.Dto.CarPricingDtos;
using CarBook.Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task< IActionResult>Index()
        {

            ViewBag.v1 = "Araçlarımız";
            ViewBag.v2 = "Aracınızı seçiniz";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7192/api/CarPricings");
            if (responseMessage.IsSuccessStatusCode)
            {
                var dataJson = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingsListWithCarsDto>>(dataJson);
                return View(values);
            }
            return View();
        }
        public async Task< IActionResult> CarDetail(int id)
        {
            ViewBag.carId = id;
            ViewBag.v1 = "Araç Detayları";
            ViewBag.v2 = "Aracın Teknik Aksesuar ve Özellikleri";
            return View();
        }
    }
}
