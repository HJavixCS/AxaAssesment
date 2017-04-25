using System;

namespace HJCS.WebApi.Models
{
    public class Policy
    {
        public int Id { get; set; }
        public double AmountInsured { get; set; }
        public string EMail { get; set; }
        public DateTime InceptionDate { get; set; }
        public bool InstallmentPayment { get; set; }
        public Client Client { get; set; }
    }
}
