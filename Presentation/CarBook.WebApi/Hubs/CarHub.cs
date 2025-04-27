using Microsoft.AspNetCore.SignalR;
using System;
using System.Net.Http;

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
            
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
                
            
            

        }


    }
}
