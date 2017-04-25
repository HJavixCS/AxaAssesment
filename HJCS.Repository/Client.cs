namespace HJCS.Infrastructure
{
    public class Client : DomainModel
    {
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Role { get; set; }

        public Client(string id):base(id) { }
    }
}
