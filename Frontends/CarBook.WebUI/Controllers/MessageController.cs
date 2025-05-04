using CarBook.Dto.BlogDtos;
using CarBook.Dto.MessageDtos;
using CarBook.Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using System.Security.Claims;
using System.Text;

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

            ViewBag.UserId=userId;  //bunu düzenlemen gerekebilşri
            ViewBag.OtherUserId = id;

            //read status kodları

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync($"https://localhost:7192/api/Messages/UpdateReadStatusBySender?senderId={id}&receiverId={userId}");
            

            // mesajları getirme işlemleri

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
        public async Task<IActionResult> CreateMessage(CreateMessageDtos createMessageDtos)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMessageDtos);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7192/api/Messages", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("MessageDetails", "Message", new { id=createMessageDtos.ReceiverID});

            }
            return View();
        }
    }
}
