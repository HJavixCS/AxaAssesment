
using System.Collections.Generic;

namespace HJCS.Repository
{
    public class ClientDto : DataModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string role { get; set; }
    }

    public class RootClientDto : RootDataModel
    {
        public List<ClientDto> clients { get; set; }
    }
}
