using System.Collections.Generic;
using System.Linq;
using HJCS.Domain.AdapterExternalServices;
using HJCS.Domain.Entities;
using HJCS.Domain.Repositories;
using HJCS.Infrastructure.DataEntities;

namespace HJCS.Infrastructure.Repositories
{
    public class PolicyRepository : IReadOnlyRepository<Policy>
    {
        private readonly IDataMapper<Policy, PolicyDto> _mapper;
        private readonly IDataRetriever<RootPolicyDto> _dataRetriever;
        private IEnumerable<Policy> _list;

        public PolicyRepository(IDataMapper<Policy, PolicyDto> mapper, IDataRetriever<RootPolicyDto> dataRetriever)
        {
            _mapper = mapper;
            _dataRetriever = dataRetriever;
        }

        public IEnumerable<Policy> All
        {
            get
            {
                if (_list == default(IEnumerable<Policy>))
                {
                    _list = GetRemotePolicys();
                }
                return _list;
            }
        }

        public Policy GetById(string id)
        {
            return All.FirstOrDefault(r => r.Id == id);
        }

        private IEnumerable<Policy> GetRemotePolicys()
        {
            var context = _dataRetriever.Retrieve();
            return context.policies.Select(r => _mapper.Map(r));
        }
    }
}
