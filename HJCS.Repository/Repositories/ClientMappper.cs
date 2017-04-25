using HJCS.Domain.Entities;
using HJCS.Domain.Repositories;
using HJCS.Infrastructure.DataEntities;

namespace HJCS.Infrastructure.Repositories
{
    public class ClientMappper : IDataMapper<Client, ClientDto>
    {
        public Client Map(ClientDto item)
        {
            return new Client(item.id)
            {
                Name = item.name,
                EMail = item.email,
                Role = item.role
            };
        }
    }
}
