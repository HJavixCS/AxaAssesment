using System.Configuration;

namespace HJCS.Repository
{
    public class ClientsRetriever : IRetriever<RootClientDto>
    {
        internal override string SourceUrl
        {
            get { return Properties.Settings.Default["ClientSourceUrl"].ToString(); }
        }
    }
}
