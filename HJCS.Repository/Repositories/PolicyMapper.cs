using System;
using HJCS.Domain.Entities;
using HJCS.Domain.Repositories;
using HJCS.Infrastructure.DataEntities;

namespace HJCS.Infrastructure.Repositories
{
    public class PolicyMapper : IDataMapper<Policy, PolicyDto>
    {
        private readonly IReadOnlyRepository<Client> _clientRepository;

        public PolicyMapper(IReadOnlyRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Policy Map(PolicyDto item)
        {
            var client = _clientRepository.GetById(item.clientId);

            return new Policy(item.id)
            {
                AmountInsured = item.amountInsured,
                EMail = item.email,
                InceptionDate = Convert.ToDateTime(item.inceptionDate),
                InstallmentPayment = item.installmentPayment,
                Client = new Client(item.clientId)
                {
                    Name = client.Name,
                    EMail = client.EMail,
                    Role = client.Role
                }
            };
        }
    }
}
