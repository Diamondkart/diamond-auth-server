namespace DiamondAuthServer.Domain.Entities.Auth
{
    public class ClientRedirectUri
    {
        public Guid ID { get; set; }
        public Guid ClientID { get; set; }
        public string RedirectUri { get; set; }
    }
}