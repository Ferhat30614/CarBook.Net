using CarBook.Dto.CarDtos;
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
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7192/api/Cars/CarWithBrandList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var dataJson = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandsDto>>(dataJson);
                return View(values);
            }
            return View();
        }
    }
}
