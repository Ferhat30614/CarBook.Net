using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        public IActionResult Index(int id)
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

            return View();
        }
    }
}
