using System;
using HJCS.Domain.AdapterExternalServices;
using HJCS.Infrastructure.DataEntities;
using Newtonsoft.Json;

namespace HJCS.Infrastructure.AdapterExternalServices
{
    public class ClientsDataRetriever : DataRetriever, IDataRetriever<RootClientDto>
    {
        //internal override string SourceUrl
        //{
        //    get { return Properties.Settings.Default["ClientsSourceUrl"].ToString(); }
        //}

        private string SourceUrl => Properties.Settings.Default["ClientsSourceUrl"].ToString();

        public RootClientDto Retrieve()
        {
            return JsonConvert.DeserializeObject<RootClientDto>(GetStringAsync(SourceUrl));
        }
    }
}
