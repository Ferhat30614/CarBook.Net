using CarBook.Dto.BlogDtos;
using CarBook.Dto.BrandDtos;
using CarBook.Dto.CarDtos;
using CarBook.Dto.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class AdminCarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
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


        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7192/api/Brands");           
            var dataJson = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(dataJson);

            List<SelectListItem> brandValues = (from x in values
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value=x.BrandID.ToString()    
                                                }).ToList();    
            
            ViewBag.BrandValues = brandValues;   

            return View();
            
        
        }


        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
        {
            var client = _httpClientFactory.CreateClient();           
            var jsonData = JsonConvert.SerializeObject(createCarDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7192/api/Cars", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();


        }



        public async Task<IActionResult> RemoveCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7192/api/Cars?id={id}");


            if (responseMessage.IsSuccessStatusCode)
            {
               return RedirectToAction("Index");
            }

            return View();


        }



        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1= await client1.GetAsync("https://localhost:7192/api/Brands");
            var dataJson1 = await responseMessage1.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<List<ResultBrandDto>>(dataJson1);

            List<SelectListItem> brandValues = (from x in values1
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.BrandID.ToString()
                                                }).ToList();

            ViewBag.BrandValues = brandValues;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7192/api/Cars/"+id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var dataJson = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCarDto>(dataJson);
                return View(values);  
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
        {
            var client = _httpClientFactory.CreateClient();
            var datajson=JsonConvert.SerializeObject(updateCarDto); 
            StringContent stringContent = new StringContent(datajson,Encoding.UTF8, "application/json");    
            var responseMessage = await client.PutAsync("https://localhost:7192/api/Cars", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");   
            }

            return View();
        }

        

    }
}
