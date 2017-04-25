using System.Configuration;

namespace HJCS.Infrastructure
{
    public class ClientsRetriever : IRetriever<RootClientDto>
    {
        internal override string SourceUrl
        {
            get { return Properties.Settings.Default["ClientSourceUrl"].ToString(); }
        }
    }
}
