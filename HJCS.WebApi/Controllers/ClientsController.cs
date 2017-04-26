using System.Linq;
using System.Web.Http;
using HJCS.Domain.Entities;
using HJCS.Domain.Repositories;

namespace HJCS.WebApi.Controllers
{
    public class ClientsController : ApiController
    {
        private readonly IReadOnlyRepository<Client> _clientRepository;
        private readonly IReadOnlyRepository<Policy> _policyRepository;

        public ClientsController(IReadOnlyRepository<Client> clientRepository, IReadOnlyRepository<Policy> policyRepository)
        {
            _clientRepository = clientRepository;
            _policyRepository = policyRepository;
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
            var client = _clientRepository.All.FirstOrDefault(t => t.Name.ToLower() == name.ToLower());
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
            var policies = _policyRepository.All.Where(t => t.Client.Name == name).ToList();
            if (!policies.Any())
            {
                return NotFound();
            }
            return Ok(policies);
        }

        [Route("api/policy/{policyId}/client")]
        [HttpGet]
        public IHttpActionResult FindClientByPolicy(string policyId)
        {
            var policy = _policyRepository.GetById(policyId);
            if (policy == default(Policy))
            {
                return NotFound();
            }
            return Ok(policy.Client);
        }
    }
}
