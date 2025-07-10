using CarBook.Dto.BlogLikeDtos;
using CarBook.Dto.TagCloudDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;


namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailLikeDislikeComponentPartial:ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailLikeDislikeComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {

            var userId = 0;
            var claim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                userId = int.Parse(claim.Value);
            }

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7192/api/BlogLikes?id={id}&AppUserId={userId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var dataJson = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultBlogLikeDto>(dataJson);
                values!.UserID = userId; 
                return View(values);

            }
            return View();
        }

    }
}
