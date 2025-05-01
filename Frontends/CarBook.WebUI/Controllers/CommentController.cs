using CarBook.Dto.CommentDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class CommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Authorize]
        public async  Task<IActionResult> AddReply(CreateReplyCommentDto createReplyCommentDto)
        {
            var claim =User.Claims.FirstOrDefault(a=>a.Type== "Username");
            var claim2 =User.Claims.FirstOrDefault(a=>a.Type== "Eposta");
            var Username = "";
            var Eposta = "";
            if (claim != null && claim2 != null )
            { 

                Username = claim.Value;
                Eposta = claim2.Value; 
            
            }

            createReplyCommentDto.Name = Username;
            createReplyCommentDto.Email = Eposta;   

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createReplyCommentDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7192/api/Comments/CreateComment", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("BlogDetails","Blog", new { id = createReplyCommentDto.BlogID });

            }
            return View();
       
        }
    }
}
