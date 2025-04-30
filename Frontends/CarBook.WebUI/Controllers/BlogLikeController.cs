using CarBook.Dto.BlogLikeDtos;
using CarBook.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class BlogLikeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogLikeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> BlogLikeDislike(CreateBlogLikeDto createBlogLikeDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBlogLikeDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7192/api/BlogLikes", content);
            
            return RedirectToAction("BlogDetails", new { id = createBlogLikeDto.BlogID });

          
        }
    }
}
