using CarBook.Dto.BlogDtos;
using CarBook.Dto.MessageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using System.Security.Claims;

namespace CarBook.WebUI.Controllers
{
    public class MessageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MessageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var claim = User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier);
            var userId = 0;

            if (claim != null) {
                userId = int.Parse(claim.Value);            
            }
           

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7192/api/Messages/GetMessageByCurrentUser?currentUserId=" + userId);
            if (responseMessage.IsSuccessStatusCode)
            {
                var dataJson = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageByCurrentUserDto>>(dataJson);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MessageDetails(int id)
        {
            var claim = User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier);
            var userId = 0;

            if (claim != null) {
                userId = int.Parse(claim.Value);            
            }

            ViewBag.UserId=userId;
            ViewBag.OtherUserId = id;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7192/api/Messages?senderId={id}&receiverId={userId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var dataJson = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageDetailsDto>>(dataJson);
                return View(values);
            }
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateMessage(int id)
        {
            var claim = User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier);
            var userId = 0;

            if (claim != null) {
                userId = int.Parse(claim.Value);            
            }

            ViewBag.UserId=userId;
            ViewBag.OtherUserId = id;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7192/api/Messages?senderId={id}&receiverId={userId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var dataJson = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageDetailsDto>>(dataJson);
                return View(values);
            }
            return View();
        }
    }
}
