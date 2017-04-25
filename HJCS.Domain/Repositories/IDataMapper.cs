using HJCS.Domain.Entities;

namespace HJCS.Domain.Repositories
{
    public interface IDataMapper<TDomainModel, TDataModel> where TDomainModel : DomainModel
    {
        TDomainModel Map(TDataModel item);
    }
}
