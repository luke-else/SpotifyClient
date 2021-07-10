using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace SpotifyClient.Controllers
{
    public static class APIClient
    {
        public static async Task<string> Get(string URI, Dictionary<string, string> Headers)
        {
            using (HttpClient Client = new HttpClient())
            {
                Client.DefaultRequestHeaders.Clear();

                //Add headers to the HTTP Client
                foreach (var item in Headers)
                {
                    Client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }

                //Make the request to the endpoint and await the request.
                var response = await Client.GetAsync(URI);

                var responseString = await response.Content.ReadAsStringAsync();

                return responseString;

            }
        }
        public static async Task<string> Put(string URI, Dictionary<string, string> Headers, Dictionary<string, string> Body)
        {
            using (HttpClient Client = new HttpClient())
            {
                Client.DefaultRequestHeaders.Clear();

                //Add headers to the HTTP Client
                foreach (var item in Headers)
                {
                    Client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }

                var content = new FormUrlEncodedContent(Body);

                //Make the request to the endpoint and await the request.
                var response = await Client.PutAsync(URI, content);

                var responseString = await response.Content.ReadAsStringAsync();

                return responseString;
            }
        }
        public static async Task<string> Post(string URI, Dictionary<string, string> Headers, Dictionary<string, string> Body)
        {
            using (HttpClient Client = new HttpClient())
            {
                Client.DefaultRequestHeaders.Clear();

                //Add headers to the HTTP Client
                foreach (var item in Headers)
                {
                    Client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }

                var content = new FormUrlEncodedContent(Body);

                //Make the request to the endpoint and await the request.
                var response = await Client.PostAsync(URI, content);

                var responseString = await response.Content.ReadAsStringAsync();

                return responseString;
            }
        }
        public static async Task<string> Delete(string URI, Dictionary<string, string> Headers)
        {
            using (HttpClient Client = new HttpClient())
            {
                Client.DefaultRequestHeaders.Clear();

                //Add headers to the HTTP Client
                foreach (var item in Headers)
                {
                    Client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }

                //Make the request to the endpoint and await the request.
                var response = await Client.DeleteAsync(URI);

                var responseString = await response.Content.ReadAsStringAsync();

                return responseString;
            }
        }

    }
}