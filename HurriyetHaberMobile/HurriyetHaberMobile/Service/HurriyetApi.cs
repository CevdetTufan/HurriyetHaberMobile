using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HurriyetHaberMobile.Service
{
    public class HurriyetApi
    {
        private readonly string ApiKey = "";
        private readonly string Host = "api.hurriyet.com.tr";

        public string Get(string address)
        {
            string resultString = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                HttpContent content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("Host",Host),
                    new KeyValuePair<string, string>("User Agent","Gelato API Explorer"),
                    new KeyValuePair<string, string>("Content-Type","application/json")
                });

                string url = $"{Host}/{address}";
                HttpResponseMessage response = client.PostAsync(url, content).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                     resultString = response.Content.ReadAsStringAsync().Result;
                }
            }
            return resultString;
        }
    }
}
