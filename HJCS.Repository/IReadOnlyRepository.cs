using System.Collections.Generic;

namespace HJCS.Repository
{
    public interface IReadOnlyRepository<TDomainModel> where TDomainModel: DomainModel
    {
        IList<TDomainModel> List { get; }
        TDomainModel GetById(string id);
    }
}
