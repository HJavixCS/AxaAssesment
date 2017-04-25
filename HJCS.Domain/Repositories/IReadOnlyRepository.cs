using System.Collections.Generic;
using HJCS.Domain.Entities;

namespace HJCS.Domain.Repositories
{
    public interface IReadOnlyRepository<TDomainModel> where TDomainModel: DomainModel
    {
        IList<TDomainModel> List { get; }
        TDomainModel GetById(string id);
    }
}
