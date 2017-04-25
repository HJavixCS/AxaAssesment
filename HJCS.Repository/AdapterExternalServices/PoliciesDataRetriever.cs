using HJCS.Domain.AdapterExternalServices;
using HJCS.Infrastructure.DataEntities;
using Newtonsoft.Json;

namespace HJCS.Infrastructure.AdapterExternalServices
{
    public class PoliciesDataRetriever : DataRetriever, IDataRetriever<RootPolicyDto>
    {
        private string SourceUrl => Properties.Settings.Default["PoliciesSourceUrl"].ToString();

        public RootPolicyDto Retrieve()
        {
            return JsonConvert.DeserializeObject<RootPolicyDto>(GetStringAsync(SourceUrl));
        }
    }
}
