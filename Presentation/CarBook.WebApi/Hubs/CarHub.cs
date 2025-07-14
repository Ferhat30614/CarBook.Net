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
using CarBook.WebApi.Models.MessageModels;


namespace CarBook.WebApi.Hubs
{
    public class CarHub(IHttpClientFactory _httpClientFactory) :Hub
    {

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
                

                await Clients.Others.SendAsync("ReceiveBlogLikeDislikeOthers", values!.BlogID,values.LikeCount, values.DislikeCount);
                await Clients.Caller.SendAsync("ReceiveBlogLikeDislike", values.UserVote, values.LikeCount, values.DislikeCount);




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



        public async Task AddAndUpdateMessage(int CurrentUserIdForMessage, int OtherUserIdForMessage, string MessageContent)
        {


            var messageContent=MessageContent.Trim();

            if (!string.IsNullOrEmpty(messageContent)) {


                // Mesaj Ekle 

                var createMessageModel = new CreateMessageModel
                {
                    SenderID = CurrentUserIdForMessage,
                    ReceiverID = OtherUserIdForMessage,
                    Content = MessageContent
                };


                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createMessageModel);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7192/api/Messages", content);

                //Güncel Mesajları getir 


                var client2 = _httpClientFactory.CreateClient();
                var responseMessage2 = await client2.GetAsync($"https://localhost:7192/api/Messages?senderId={OtherUserIdForMessage}&receiverId={CurrentUserIdForMessage}");

                var dataJson = await responseMessage2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageDetailsModel>>(dataJson);

                await Clients.All.SendAsync("getUpdatedMessages", values, CurrentUserIdForMessage, OtherUserIdForMessage);


            }     




             
        }

    }
}
