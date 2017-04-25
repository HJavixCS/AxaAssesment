namespace HJCS.Repository
{
    public abstract class DomainModel
    {
        public string Id { get; protected set; }

        protected DomainModel(string id)
        {
            Id = id;
        }
    }
}
