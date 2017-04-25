using HJCS.Domain.Entities;

namespace HJCS.Domain.AdapterExternalServices
{
    public interface IDataRetriever<TDataModel> where TDataModel : DataModel
    {
        TDataModel Retrieve();
    }
}
