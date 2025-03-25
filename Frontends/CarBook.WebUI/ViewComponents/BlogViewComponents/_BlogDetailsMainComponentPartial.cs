using CarBook.Dto.BlogDtos;
using CarBook.Dto.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsMainComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsMainComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage2 = await client.GetAsync($"https://localhost:7192/api/Comments/GetCountCommentByBlog?id="+id);
            var dataJson2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.CommentCount = dataJson2;


            var responseMessage = await client.GetAsync($"https://localhost:7192/api/Blogs/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var dataJson = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetBlogByIdDto>(dataJson);
                return View(values);

            }
            return View();


        }
    }
}
