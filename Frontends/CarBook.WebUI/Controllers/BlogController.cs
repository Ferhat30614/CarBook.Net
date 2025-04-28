using CarBook.Dto.BlogDtos;
using CarBook.Dto.CarPricingDtos;
using CarBook.Dto.CommentDtos;
using CarBook.Dto.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
           
            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Yazarlarımızın Blogları";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7192/api/Blogs/GetAllBlogsWithAuthorsList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var dataJson = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorsDto>>(dataJson);
                return View(values);
            }
            return View();
        }

        public IActionResult BlogDetails(int id)
        {
            ViewBag.BlogId = id;

            ViewBag.v1 = "BloglarDetay";
            ViewBag.v2 = "Yazarlarımızın Bloglarını detayı";
            
            return View();
        }


        [HttpGet]
        public PartialViewResult AddComment(int id) 
        {
            ViewBag.BlogId = id;
            return PartialView();
        }


        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCommentDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7192/api/Comments/CreateComment", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction( "BlogDetails", new {id=createCommentDto.BlogID});

            }
            return View();

        }
    }
}
