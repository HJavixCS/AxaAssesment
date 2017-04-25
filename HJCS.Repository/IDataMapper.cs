namespace HJCS.Repository
{
    public interface IDataMapper<TDomainModel, TDataModel> where TDomainModel : DomainModel where TDataModel : DataModel
    {
        TDomainModel Map(TDataModel item);
    }
}
