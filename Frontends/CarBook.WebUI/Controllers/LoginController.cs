using CarBook.Dto.LoginDtos;
using CarBook.Dto.RegisterDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonSerializer.Serialize(createLoginDto),Encoding.UTF8,"application/json");
            var response = await client.PostAsync("https://localhost:7192/api/Login",content);

            if (response != null)
            {
                var dataJson=await response.Content.ReadAsStringAsync();
                var tokenModel=
            }

            
            return View();
        }
    }
}
