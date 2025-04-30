using CarBook.Dto.BlogLikeDtos;
using CarBook.Dto.CommentDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Net.Http;
using System.Security.Claims;
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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> BlogLikeDislike(bool IsLike,int BlogID)
        {
            var claim = (User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier));

            if (claim!=null)
            {
                var userid = int.Parse(claim.Value);
                var createBlogLikeDto = new CreateBlogLikeDto
                {
                    AppUserID = userid,
                    BlogID = BlogID,
                    IsLike = IsLike,
                };



                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createBlogLikeDto);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7192/api/BlogLikes", content);

                return RedirectToAction("BlogDetails", "Blog", new { id = createBlogLikeDto.BlogID });

            }

            return View();
          
        }
    }
}
