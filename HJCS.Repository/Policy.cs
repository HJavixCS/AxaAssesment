using System;

namespace HJCS.Infrastructure
{
    public class Policy : DomainModel
    {
        public double AmountInsured { get; set; }
        public string EMail { get; set; }
        public DateTime InceptionDate { get; set; }
        public bool InstallmentPayment { get; set; }
        public Client Client { get; set; }

        public Policy(string id) : base(id) { }
    }
}
