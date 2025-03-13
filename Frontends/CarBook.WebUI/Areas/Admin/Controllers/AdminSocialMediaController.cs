using CarBook.Dto.SocialMediaDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminSocialMedia")]
    public class AdminSocialMediaController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminSocialMediaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7192/api/SocialMedias");
            if (responseMessage.IsSuccessStatusCode)
            {
                var dataJson = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(dataJson);
                return View(values);
            }
            return View();
        }

        [Route("CreateSocialMedia")]
        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }

        [Route("CreateSocialMedia")]
        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSocialMediaDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7192/api/SocialMedias", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminSocialMedia", new { area = "Admin" });

            }
            return View();
        }


        [Route("RemoveSocialMedia/{id}")]
        public async Task<IActionResult> RemoveSocialMedia(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7192/api/SocialMedias?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminSocialMedia", new { area = "Admin" });
            }
            return View();
        }


        [Route("UpdateSocialMedia/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7192/api/SocialMedias/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var dataJson = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateSocialMediaDto>(dataJson);
                return View(values);
            }

            return View();
        }


        [Route("UpdateSocialMedia/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var client = _httpClientFactory.CreateClient();
            var datajson = JsonConvert.SerializeObject(updateSocialMediaDto);
            StringContent stringContent = new StringContent(datajson, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7192/api/SocialMedias", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminSocialMedia", new { area = "Admin" });
            }

            return View();
        }
    }
}
