using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DadJokesLibrary
{
    public class DadJokesProcessor
    {
        public static async Task<DadJokeItem> LoadRandomJoke()
        {
            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(APIHelper.ApiClient.BaseAddress))
            {
                if (response.IsSuccessStatusCode)
                {
                    DadJokeItem joke = await response.Content.ReadAsAsync<DadJokeItem>();

                    return joke;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<DadJokes> SearchJokes(string searchTerm)
        {
            string url = string.Empty;

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                url = $"{ APIHelper.ApiClient.BaseAddress }/search?limit=30&term={ searchTerm }";
            }
            else
            {
                url = $"{ APIHelper.ApiClient.BaseAddress }/search?limit=30";
            }

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    DadJokes jokes = await response.Content.ReadAsAsync<DadJokes>();

                    return jokes;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
