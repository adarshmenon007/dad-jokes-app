using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DadJokesLibrary
{
    public class APIHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("https://icanhazdadjoke.com/");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ApiClient.DefaultRequestHeaders.Add("User-Agent", @"My Library (https://github.com/adarshmenon007/dad-jokes-app)");
        }
    }
}
