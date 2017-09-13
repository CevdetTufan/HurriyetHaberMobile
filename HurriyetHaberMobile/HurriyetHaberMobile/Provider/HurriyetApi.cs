using System.Net.Http;

namespace HurriyetHaberMobile.Provider
{
    public class HurriyetApi : ServiceBase
    {
        private readonly string apiKey = "hurriyet_api_key";
        private readonly string host = "https://api.hurriyet.com.tr";
        public override string Get(string address)
        {
            string resultString = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("accept", "application/json");
                client.DefaultRequestHeaders.Add("apikey", apiKey);

                HttpResponseMessage response = client.GetAsync($"{host}/{address}").Result;
                resultString = response.Content.ReadAsStringAsync().Result;
            }
            return resultString;
        }
    }
}
