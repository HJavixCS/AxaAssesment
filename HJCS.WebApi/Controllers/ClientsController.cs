using System.Linq;
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

        [Route("api/client/name/{name}")]
        public IHttpActionResult GetClientByName(string name)
        {
            var client = _clientRepository.List.FirstOrDefault(t => t.Name.ToLower() == name.ToLower());
            if (client == default(Client))
            {
                return NotFound();
            }
            return Ok(client);
        }

        [Route("api/client/name/{name}/policies")]
        [HttpGet]
        public IHttpActionResult FindPoliciesByClientName(string name)
        {
            return Ok("FindPoliciesByClientName");
        }

        [Route("api/policy/{id}/client")]
        [HttpGet]
        public IHttpActionResult FindClientByPolicy(string id)
        {
            return Ok("FindClientByPolicy");
        }
    }
}
