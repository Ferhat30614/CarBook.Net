using CarBook.Dto.LocationDtos;
using CarBook.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace CarBook.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var token = User.Claims.FirstOrDefault(a => a.Type == "accesToken").Value; // burada User, şu anki oturum açmış kullanıcıyı temsil eder. ve kullanımı httpcontext üzerinden yani kütüphane gerekmez...
            // User.Claims diyerek ben geçerli  kullanıcının tüm claims değerlerine erişmiş olurum ve zaten
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var responseMessage = await client.GetAsync("https://localhost:7192/api/Locations");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var dataJson = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(dataJson);

                    List<SelectListItem> values2 = (from x in values
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.LocationID.ToString()
                                                    }).ToList();
                    ViewBag.v = values2;

                }
            }
            return View();
        }

        [HttpPost]
        public  IActionResult Index(string time_pick,string time_off,string book_off_date,string book_pick_date,string  LocationID)
        {
            TempData["time_pick"] = time_pick;
            TempData["time_off"] = time_off;
            TempData["book_pick_date"] = book_pick_date;
            TempData["book_off_date"] = book_off_date;
            TempData["LocationID"] = LocationID;
            return RedirectToAction("Index", "RentACarList");               
        }
    }
}
