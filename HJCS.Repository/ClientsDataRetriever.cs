using System.Configuration;
using HJCS.Domain.Repositories;

namespace HJCS.Infrastructure
{
    public class ClientsDataRetriever : DataRetriever<RootClientDto>
    {
        internal override string SourceUrl
        {
            get { return Properties.Settings.Default["ClientSourceUrl"].ToString(); }
        }
    }
}
