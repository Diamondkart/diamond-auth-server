namespace DiamondAuthServer.Domain.Entities.Auth
{
    public class Client
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string ClientType { get; set; }
        public bool Enabled { get; set; }
        public bool RequireClientSecret { get; set; }
        public bool RequirePkce { get; set; }
        public string AllowOfflineAccess { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool AlwaysIncludeUserClaimsInIdToken { get; set; }
        public List<ClientGrantType> GrantTypes { get; set; }
        public List<ClientScope> Scopes { get; set; }
    }
}