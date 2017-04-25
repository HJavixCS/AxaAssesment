using System.Net.Http;
using Newtonsoft.Json;

namespace HJCS.Repository
{
    public abstract class IRetriever<TDataModel> where TDataModel : DataModel
    {
        internal abstract string SourceUrl { get; }

        public TDataModel Retrieve()
        {
            return JsonConvert.DeserializeObject<TDataModel>(GetStringAsync(SourceUrl));
        }

        private static string GetStringAsync(string url)
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
