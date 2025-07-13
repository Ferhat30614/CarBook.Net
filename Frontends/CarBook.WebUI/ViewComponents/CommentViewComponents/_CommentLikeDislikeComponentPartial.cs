using CarBook.Dto.CommentLikeDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace CarBook.WebUI.ViewComponents.CommentViewComponents
{
    public class _CommentLikeDislikeComponentPartial : ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public _CommentLikeDislikeComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? id)
        {

            var userId = 0;
            var claim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                userId = int.Parse(claim.Value);
            }

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7192/api/CommentLikes?id={id}&AppUserId={userId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var dataJson = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultCommentLikeDto>(dataJson);
                return View(values);

            }
            return View();
        }

    }
}
