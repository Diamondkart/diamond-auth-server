namespace DiamondAuthServer.Domain.Entities.Auth
{
    public class ClientProperty
    {
        public Guid ID { get; set; }
        public Guid ClientID { get; set; }
        public string Property { get; set; }
    }
}