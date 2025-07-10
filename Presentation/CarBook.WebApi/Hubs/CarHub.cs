using CarBook.Domain.Entities;
using CarBook.WebApi.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;


namespace CarBook.WebApi.Hubs
{
    public class CarHub:Hub
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public CarHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

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
            var responseMessage2 = await client.GetAsync($"https://localhost:7192/api/BlogLikes?id={BlogId}&AppUserId={UserId}");
            
            var dataJson = await responseMessage2.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultBlogLikeModel>(dataJson);


            await Clients.All.SendAsync("ReceiveBlogLikeDislike",values); 
            
        }


    }
}
