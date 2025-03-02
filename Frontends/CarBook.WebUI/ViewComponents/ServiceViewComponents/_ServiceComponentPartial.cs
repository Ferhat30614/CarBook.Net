﻿using CarBook.Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.ServiceViewComponents
{
    public class _ServiceComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ServiceComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7192/api/Services");
            if (responseMessage.IsSuccessStatusCode)
            {
                var dataJson = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(dataJson);
                return View(values);
            }
            return View();
        }

    }
}
