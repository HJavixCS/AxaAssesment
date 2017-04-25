using HJCS.Infrastructure;
using HJCS.Infrastructure.AdapterExternalServices;
using HJCS.Infrastructure.Repositories;


namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientMapper = new ClientMappper();//TODO: Inject
            var clientRetriever = new ClientsDataRetriever();//TODO: Inject

            var clientRepository = new ClientRepository(clientMapper, clientRetriever);


            var policyMapper = new PolicyMapper(clientRepository);
            var policyRetriever = new PoliciesDataRetriever();//TODO: Inject
            var policyRepository = new PolicyRepository(policyMapper, policyRetriever);

            var clientsList = clientRepository.List;
            var client = clientRepository.GetById("0178914c-548b-4a4c-b918-47d6a391530c");


            var policiesList = policyRepository.List;
            var policy = policyRepository.GetById("7b624ed3-00d5-4c1b-9ab8-c265067ef58b");
        }
    }
}
