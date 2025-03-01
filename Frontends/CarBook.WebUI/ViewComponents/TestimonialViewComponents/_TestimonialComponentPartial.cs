using CarBook.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.TestimonialViewComponents
{
    public class _TestimonialComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _TestimonialComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7192/api/Testimonials");
            if (responseMessage.IsSuccessStatusCode) 
            {
                var dataJson = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(dataJson);
                return View(values);
            }
            return View();
        }
    }
}
