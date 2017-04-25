using System.Collections.Generic;
using System.Linq;
using HJCS.Domain.Entities;
using HJCS.Domain.Repositories;

namespace HJCS.Infrastructure
{
    public class ClientRepository : IReadOnlyRepository<Client>
    {
        private readonly IDataMapper<Client, ClientDto> _mapper;
        private readonly DataRetriever<RootClientDto> _dataRetriever;
        private IList<Client> _list;

        public ClientRepository(IDataMapper<Client, ClientDto> mapper, DataRetriever<RootClientDto> dataRetriever)
        {
            _mapper = mapper;
            _dataRetriever = dataRetriever;
        }

        public IList<Client> List
        {
            get
            {
                if (_list == default(IEnumerable<Client>))
                {
                    _list = GetRemoteClients().ToList();
                }
                return _list;
            }
        }

        public Client GetById(string id)
        {
            return List.FirstOrDefault(r => r.Id == id);
        }

        private IEnumerable<Client> GetRemoteClients()
        {
            var clients = _dataRetriever.Retrieve();
            return clients.clients.Select(r => _mapper.Map(r));
        }
    }
}
