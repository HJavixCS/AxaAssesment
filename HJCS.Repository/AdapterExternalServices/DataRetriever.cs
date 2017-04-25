using System.Net.Http;
using HJCS.Domain.Entities;
using Newtonsoft.Json;

namespace HJCS.Infrastructure.AdapterExternalServices
{
    public abstract class DataRetriever<TDataModel> where TDataModel : DataModel
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
