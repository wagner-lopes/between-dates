using unitTests.BetweenDates.Response;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace unitTests.BetweenDates
{
    public class BetweenDatesAPI
    {
        private HttpClient restClient = new HttpClient();
        private string URL = "http://localhost:3001/interval";

        public async Task<getInterval> getInterval(RequestData data)
        {
            HttpClient client = new HttpClient();

            string json = JsonConvert.SerializeObject(data);

            UriBuilder builder = new UriBuilder($"{URL}");
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await restClient.PostAsync(URL, httpContent);
            var context = await response.Content.ReadAsStringAsync();

            try
            {
                var responseModel = JsonConvert.DeserializeObject<getInterval>(context);
                return responseModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}