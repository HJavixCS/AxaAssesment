using System.Web.Http;
using HJCS.Domain.Entities;
using HJCS.Domain.Repositories;

namespace HJCS.WebApi.Controllers
{
    public class ClientsController : ApiController
    {
        private readonly IReadOnlyRepository<Client> _clientRepository;

        public ClientsController(IReadOnlyRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public IHttpActionResult GetClient(string id)
        {
            var client = _clientRepository.GetById(id);
            if (client == default(Client))
            {
                return NotFound();
            }
            return Ok(client);
        }
    }
}
