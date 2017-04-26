using System.Collections.Generic;
using System.Linq;
using HJCS.Domain.AdapterExternalServices;
using HJCS.Domain.Entities;
using HJCS.Domain.Repositories;
using HJCS.Infrastructure.DataEntities;
using HJCS.Infrastructure.Repositories;
using NUnit.Framework;
using NSubstitute;

namespace HJCS.Tests
{
    [TestFixture]
    public class ClientRepositoryTests
    {
        private IReadOnlyRepository<Client> _repository;

        [SetUp]
        public void Initialize()
        {
            var moquedClients = new RootClientDto()
            {
                clients = new List<ClientDto>()
                {
                    new ClientDto()
                    {
                        id = "1001",
                        name = "Albert",
                        email = "abc@mail.net",
                        role = "roleA"
                    },
                    new ClientDto()
                    {
                        id = "1002",
                        name = "Bill",
                        email = "xyz@mail.net",
                        role = "roleB"
                    },
                    new ClientDto()
                    {
                        id = "1003",
                        name = "Carl",
                        email = "22cc@mail.net",
                        role = "roleA"
                    },
                }
            };
            
            var retriver = Substitute.For<IDataRetriever<RootClientDto>>();
            retriver.Retrieve().Returns(moquedClients);
            _repository = new ClientRepository(new ClientMappper(), retriver);
        }

        [Test]
        public void GivenClientsData_WhenListAll_ThenGetAll()
        {
            var expectedItems = 3;
            var list = _repository.All.ToList();
            Assert.True(list.Any());
            Assert.AreEqual(expectedItems, list.Count);
        }

        [Test]
        [TestCase("1001", "Albert")]
        [TestCase("1003", "Carl")]
        public void GivenClientsData_WhenGetByExistentId_ThenGetMatchClient(string id, string expectedName)
        {
            var actualClient = _repository.GetById(id);
            Assert.AreEqual(expectedName, actualClient.Name);
        }

        [Test]
        [TestCase("999", "Albert")]
        [TestCase("acb", "Carl")]
        public void GivenClientsData_WhenGetByNonExistentId_ThenGetNullClient(string id, string expectedName)
        {
            var expectedClient = default(Client);
            var actualClient = _repository.GetById(id);
            Assert.AreEqual(expectedClient, actualClient);
        }
    }
}
