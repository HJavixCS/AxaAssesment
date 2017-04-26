using System.Collections.Generic;
using HJCS.Domain.Entities;

namespace HJCS.Domain.Repositories
{
    public interface IReadOnlyRepository<TDomainModel> where TDomainModel: DomainModel
    {
        IEnumerable<TDomainModel> All { get; }
        TDomainModel GetById(string id);
    }
}
