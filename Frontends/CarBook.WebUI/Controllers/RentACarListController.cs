using CarBook.Dto.CarDtos;
using CarBook.Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(int id)
        {
            var timepick = TempData["time_pick"];
            var timeoff = TempData["time_off"];
            var bookpickdate = TempData["book_pick_date"];
            var bookoffdate = TempData["book_off_date"];
            var LocationID = TempData["LocationID"];
           
            ViewBag.timepick = timepick;
            ViewBag.timeoff = timeoff;
            ViewBag.bookpickdate = bookpickdate;
            ViewBag.bookoffdate = bookoffdate;
            ViewBag.LocationID = LocationID;

            id = int.Parse(LocationID.ToString());            

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7192/api/RentACars?LocationID={id}&Available=true");
            if (responseMessage.IsSuccessStatusCode)
            {
                var dataJson = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(dataJson);
                return View(values);
            }
            return View();


        }
    }
}