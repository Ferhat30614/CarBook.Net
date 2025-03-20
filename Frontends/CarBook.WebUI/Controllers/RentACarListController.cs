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
        public async Task<IActionResult> Index(FilterRentACarDto  filterRentACarDto)
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

            filterRentACarDto.Available = true;
            filterRentACarDto.LocationID = LocationID;

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(filterRentACarDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7192/api/RentACars", content);
            return View();
        }
    }
}