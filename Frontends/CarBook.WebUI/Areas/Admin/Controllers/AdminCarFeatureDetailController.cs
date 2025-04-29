using CarBook.Dto.CarDtos;
using CarBook.Dto.CarFeatureDtos;
using CarBook.Dto.CategoryDtos;
using CarBook.Dto.FeatureDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    [Route("Admin/AdminCarFeatureDetail")]
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7192/api/CarFeatures?id="+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var dataJson = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(dataJson);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> resultCarFeatureByCarIdDto)
        {
            foreach (var item in resultCarFeatureByCarIdDto) {


                if (item.Available == true)
                {
                    var client = _httpClientFactory.CreateClient();
                    var responseMessage = await client.GetAsync("https://localhost:7192/api/CarFeatures/CarFeatureAvailableChangeToTrue?id=" + item.CarFeatureID);
                }
                else
                {
                    var client = _httpClientFactory.CreateClient();
                    var responseMessage = await client.GetAsync("https://localhost:7192/api/CarFeatures/CarFeatureAvailableChangeToFalse?id=" + item.CarFeatureID);

                }
            }

            return RedirectToAction("Index", "AdminCar");

        }


        [HttpGet]
        [Route("CreateFeatureByCarId/{id}")]
        public async Task<IActionResult> CreateFeatureByCarId(int id)
        {

            ViewBag.CarId = id;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7192/api/Features");
            if (responseMessage.IsSuccessStatusCode)
            {
                var dataJson = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<CreateCarFeatureByCarIdDto>>(dataJson);
                return View(values);
            }
            return View();


        }
        
        [HttpPost]
        [Route("CreateFeatureByCarId/{id}")]
        public async Task<IActionResult> CreateFeatureByCarId(List<CreateCarFeatureByCarIdDto> createCarFeatureByCarIdDtos)
        {

            foreach (var item in createCarFeatureByCarIdDtos)
            {


                if (item.Available == true)
                {
                    var client = _httpClientFactory.CreateClient();
                    var jsonData = JsonConvert.SerializeObject(item);                   

                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var responseMessage = await client.PostAsync("https://localhost:7192/api/CarFeatures", content);


                }
                
            }

            return RedirectToAction("Index", "AdminCar");


          
           
            

        }
    }
}
