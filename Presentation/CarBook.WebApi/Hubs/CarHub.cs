using CarBook.Domain.Entities;
using CarBook.WebApi.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


namespace CarBook.WebApi.Hubs
{
    public class CarHub:Hub
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public CarHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }





        //public override async Task OnConnectedAsync()
        //{
        //    var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        //    if (!string.IsNullOrEmpty(userId))
        //    {
        //        // Kullanıcıya özel grup
        //        await Groups.AddToGroupAsync(Context.ConnectionId, $"user_{userId}");
        //    }

        //    await base.OnConnectedAsync();
        //}



        public async Task SendCarCount()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7192/api/Statistics/GetCarCount");
            
            var value = await responseMessage.Content.ReadAsStringAsync();

            await Clients.All.SendAsync("ReceiveCarCount",value); 
            
        }


    


        public async Task BlogLikeDislike(int BlogId,int UserId,bool UserVote)
        {

                var createBlogLikeModel = new CreateBlogLikeModel
                {
                    AppUserID = UserId,
                    BlogID = BlogId,
                    IsLike = UserVote,
                };


                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createBlogLikeModel);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7192/api/BlogLikes", content);


                var client2 = _httpClientFactory.CreateClient();
                var responseMessage2 = await client2.GetAsync($"https://localhost:7192/api/BlogLikes?id={BlogId}&AppUserId={UserId}");

                var dataJson = await responseMessage2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultBlogLikeModel>(dataJson);
                

                await Clients.Others.SendAsync("ReceiveBlogLikeDislikeOthers", BlogId,UserId ,values.LikeCount,values.DislikeCount);




            // ✅ Bağlantıyı kuran kullanıcıyı tekrar tanı
            // var userIdFromToken = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;



            //var userIdFromToken = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //Console.WriteLine("UserID from token: " + userIdFromToken);

            ////// Kullanıcıya özel mesaj gönder
            ////    if (!string.IsNullOrEmpty(userIdFromToken))
            ////    {
            ////        await Clients.Group($"user_{userIdFromToken}").SendAsync("ReceiveBlogLikeDislike", BlogId, UserId, UserVote,values.LikeCount, values.DislikeCount);
            ////    }


        }


    }
}
