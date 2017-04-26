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
    public class PolicyRepositoryTests
    {
        private IReadOnlyRepository<Policy> _repository;

        [SetUp]
        public void Initialize()
        {
            var moquedPolicies = new RootPolicyDto()
            {
                policies = new List<PolicyDto>()
                {
                    new PolicyDto()
                    {
                        id = "1001",
                        amountInsured = 20.4,
                        clientId = "101",
                        inceptionDate = "2017/07/01",
                        email = "abc@mail.net",
                        installmentPayment = true
                    },
                    new PolicyDto()
                    {
                        id = "1002",
                        amountInsured = 50.6,
                        clientId = "102",
                        inceptionDate = "2017/03/01",
                        email = "xyz@mail.net",
                        installmentPayment = true
                    },
                    new PolicyDto()
                    {
                        id = "1003",
                        amountInsured = 72.5,
                        clientId = "103",
                        inceptionDate = "2017/05/01",
                        email = "a1b2b3@mail.net",
                        installmentPayment = false
                    }
                }
            };

            var clientRepository = Substitute.For<IReadOnlyRepository<Client>>();
            clientRepository.GetById(Arg.Any<string>()).Returns(new Client(""));
            var retriver = Substitute.For<IDataRetriever<RootPolicyDto>>();
            retriver.Retrieve().Returns(moquedPolicies);

            _repository = new PolicyRepository(new PolicyMapper(clientRepository), retriver);
        }

        [Test]
        public void GivenPoliciesData_WhenListAll_ThenGetAll()
        {
            var expectedItems = 3;
            var list = _repository.All.ToList();
            Assert.True(list.Any());
            Assert.AreEqual(expectedItems, list.Count);
        }

        [Test]
        [TestCase("1001", "abc@mail.net")]
        [TestCase("1003", "a1b2b3@mail.net")]
        public void GivenPoliciesData_WhenGetByExistentId_ThenGetMatchPolicy(string id, string expectdEmail)
        {
            var actualPolicy = _repository.GetById(id);
            Assert.AreEqual(expectdEmail, actualPolicy.EMail);
        }

        [Test]
        [TestCase("999", "abc@mail.net")]
        [TestCase("acb", "a1b2b3@mail.net")]
        public void GivenPoliciesData_WhenGetByNonExistentId_ThenGetNullPolicy(string id, string expectdEmail)
        {
            var expetecPolicy = default(Policy);
            var actualPolicy = _repository.GetById(id);
            Assert.AreEqual(expetecPolicy, actualPolicy);
        }
    }
}
