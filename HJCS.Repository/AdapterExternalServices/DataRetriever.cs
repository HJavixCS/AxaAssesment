using System.Net.Http;

namespace HJCS.Infrastructure.AdapterExternalServices
{
    public class DataRetriever
    {
        internal static string GetStringAsync(string url)
        {
            var responseString = string.Empty;
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    responseString = responseContent.ReadAsStringAsync().Result;
                }
            }
            return responseString;
        }
    }
}
