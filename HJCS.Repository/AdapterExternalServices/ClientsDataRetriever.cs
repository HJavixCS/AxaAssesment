using HJCS.Infrastructure.DataEntities;

namespace HJCS.Infrastructure.AdapterExternalServices
{
    public class ClientsDataRetriever : DataRetriever<RootClientDto>
    {
        internal override string SourceUrl
        {
            get { return Properties.Settings.Default["ClientSourceUrl"].ToString(); }
        }
    }
}
