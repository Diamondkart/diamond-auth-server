namespace DiamondAuthServer.Domain.Entities.Auth
{
    public class Token
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int IdentityTokenLifetime { get; set; }
        public int AccessTokenLifetime { get; set; }
        public int AuthorizationCodeLifetime { get; set; }
        public bool IncludeJwtId { get; set; }
    }
}