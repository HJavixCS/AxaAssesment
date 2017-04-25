using HJCS.Domain.Entities;

namespace HJCS.Domain.Repositories
{
    public interface IDataMapper<TDomainModel, TDataModel> 
        where TDomainModel : DomainModel
        where TDataModel : DataModel
    {
        TDomainModel Map(TDataModel item);
    }
}
