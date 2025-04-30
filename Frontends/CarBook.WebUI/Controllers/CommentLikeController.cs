using CarBook.Dto.CommentLikeDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class CommentLikeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CommentLikeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CommentLikeDislike(bool IsLike, int CommentID,int BlogID)
        {
            var claim = (User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier));

            if (claim != null)
            {
                var userid = int.Parse(claim.Value);
                var createCommentLikeDto = new CreateCommentLikeDto
                {
                    AppUserID = userid,
                    CommentID = CommentID,  
                    IsLike = IsLike,
                };



                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createCommentLikeDto);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7192/api/CommentLikes", content);

                return RedirectToAction("BlogDetails", "Blog", new { id = BlogID });

            }

            return View();

        }
    }
}
