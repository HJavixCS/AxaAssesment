using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace HJCS.Infrastructure
{
    public class ClientRepository : IReadOnlyRepository<Client>
    {
        private readonly IDataMapper<Client, ClientDto> _mapper;
        private readonly IRetriever<RootClientDto> _retriever;
        private IList<Client> _list;

        public ClientRepository(IDataMapper<Client, ClientDto> mapper, IRetriever<RootClientDto> retriever)
        {
            _mapper = mapper;
            _retriever = retriever;
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
            var clients = _retriever.Retrieve();
            return clients.clients.Select(r => _mapper.Map(r));
        }
    }
}
