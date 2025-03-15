using CarBook.Dto.AuthorDtos;
using CarBook.Dto.StatisticDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            Random random = new Random();
            var client = _httpClientFactory.CreateClient();

            #region CarCount
            var responseMessage = await client.GetAsync("https://localhost:7192/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                int CarCountRandom = random.Next(0,101);
                var dataJson = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(dataJson);
                ViewBag.CarCount = values.CarCount;
                ViewBag.CarCountRandom = CarCountRandom;
            }
            #endregion

            #region LocationCount
            var responseMessage2 = await client.GetAsync("https://localhost:7192/api/Statistics/GetLocationCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                int LocationCountRandom = random.Next(0, 101);
                var dataJson2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticDto>(dataJson2);
                ViewBag.LocationCount = values2.LocationCount;
                ViewBag.LocationCountRandom = LocationCountRandom;
            }
            #endregion

            #region AuthorCount
            var responseMessage3 = await client.GetAsync("https://localhost:7192/api/Statistics/GetAuthorCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                int AuthorCountRandom = random.Next(0, 101);
                var dataJson3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultStatisticDto>(dataJson3);
                ViewBag.AuthorCount = values3.AuthorCount;
                ViewBag.AuthorCountRandom = AuthorCountRandom;
            }
            #endregion

            #region BlogCount
            var responseMessage4 = await client.GetAsync("https://localhost:7192/api/Statistics/GetBlogCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                int BlogCountRandom = random.Next(0, 101);
                var dataJson4 = await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultStatisticDto>(dataJson4);
                ViewBag.BlogCount = values4.BlogCount;
                ViewBag.BlogCountRandom = BlogCountRandom;
            }
            #endregion

            #region BrandCount
            var responseMessage5 = await client.GetAsync("https://localhost:7192/api/Statistics/GetBrandCount");
            if (responseMessage5.IsSuccessStatusCode)
            {
                int BrandCountRandom = random.Next(0, 101);
                var dataJson5 = await responseMessage5.Content.ReadAsStringAsync();
                var values5 = JsonConvert.DeserializeObject<ResultStatisticDto>(dataJson5);
                ViewBag.BrandCount = values5.BrandCount;
                ViewBag.BrandCountRandom = BrandCountRandom;
            }
            #endregion



            return View();
        }
    }
}
