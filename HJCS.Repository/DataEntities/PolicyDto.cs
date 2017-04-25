using System.Collections.Generic;
using HJCS.Domain.Entities;

namespace HJCS.Infrastructure.DataEntities
{
    public class PolicyDto
    {
        public string id { get; set; }
        public double amountInsured { get; set; }
        public string email { get; set; }
        public string inceptionDate { get; set; }
        public bool installmentPayment { get; set; }
        public string clientId { get; set; }
    }

    public class RootPolicyDto : RootDataModel
    {
        public List<PolicyDto> policies { get; set; }
    }
}
