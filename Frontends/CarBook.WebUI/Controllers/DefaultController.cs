using CarBook.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
