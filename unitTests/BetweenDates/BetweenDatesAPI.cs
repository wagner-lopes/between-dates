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
        private string startDate;
        private string endDate;
        private string dateFormat;

        public async Task<getInterval> getInterval()
        {
            Request requestObject = new Request();
            requestObject.startDate = "2022-08-07";
            requestObject.endDate = "2022-08-12";

            HttpClient client = new HttpClient();

            string json = JsonConvert.SerializeObject(requestObject);

            UriBuilder builder = new UriBuilder($"{URL}");
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await restClient.PostAsync(URL, httpContent);
            var context = await response.Content.ReadAsStringAsync();

            try
            {
                var responseModel = JsonConvert.DeserializeObject<getInterval>(context);
                return responseModel;
            }
            catch
            {
                return null;
            }
        }
    }
}