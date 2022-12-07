﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static Android.Provider.DocumentsContract;

namespace MauiWheater.Services
{
    public static class Api
    {
        static RestClient client = new RestClient("http://dataservice.accuweather.com");
        public static string ApiKey { get; set; }
        public static string JsonContent { get; set; }

        public static async Task SearchCity(string name)
        {
            var request = new RestRequest("locations/v1/cities/autocomplete", Method.Get)
                .AddQueryParameter("apikey", ApiKey)
                .AddQueryParameter("q", name);
            RestResponse response = client.GetAsync(request).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                JsonContent = response.Content;
            else
                throw new Exception(response.StatusCode.ToString());
        }

        public static async Task GetInfoCity(string cityCode, string language = "pt-br")
        {
            var request = new RestRequest($"forecasts/v1/daily/1day/{cityCode}", Method.Get)
                .AddQueryParameter("apikey", ApiKey)
                .AddQueryParameter("language", language)
                .AddQueryParameter("metric", true);
            RestResponse response = client.GetAsync(request).Result;
            JsonContent = response.Content;
        }
    }
}
