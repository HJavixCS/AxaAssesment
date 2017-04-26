using System.Collections.Generic;
using System.Linq;
using HJCS.Domain.AdapterExternalServices;
using HJCS.Domain.Entities;
using HJCS.Domain.Repositories;
using HJCS.Infrastructure.DataEntities;

namespace HJCS.Infrastructure.Repositories
{
    public class ClientRepository : IReadOnlyRepository<Client>
    {
        private readonly IDataMapper<Client, ClientDto> _mapper;
        private readonly IDataRetriever<RootClientDto> _dataRetriever;
        private IEnumerable<Client> _list;

        public ClientRepository(IDataMapper<Client, ClientDto> mapper, IDataRetriever<RootClientDto> dataRetriever)
        {
            _mapper = mapper;
            _dataRetriever = dataRetriever;
        }

        public IEnumerable<Client> All
        {
            get
            {
                if (_list == default(IEnumerable<Client>))
                {
                    _list = GetRemoteClients();
                }
                return _list;
            }
        }

        public Client GetById(string id)
        {
            return All.FirstOrDefault(r => r.Id == id);
        }

        private IEnumerable<Client> GetRemoteClients()
        {
            var context = _dataRetriever.Retrieve();
            return context.clients.Select(r => _mapper.Map(r));
        }
    }
}
