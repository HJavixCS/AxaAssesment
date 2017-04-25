using HJCS.Infrastructure.DataEntities;

namespace HJCS.Infrastructure.AdapterExternalServices
{
    public class PoliciesDataRetriever : DataRetriever<RootPolicyDto>
    {
        internal override string SourceUrl
        {
            get { return Properties.Settings.Default["PoliciesSourceUrl"].ToString(); }
        }
    }
}
