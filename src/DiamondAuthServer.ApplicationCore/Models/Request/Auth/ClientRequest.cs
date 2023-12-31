namespace DiamondAuthServer.ApplicationCore.Models.Request.Auth
{
    public class ClientRequest
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

        public bool IsClientTypeValid()
        {
            return Meta.ClientTypeList.Contains(ClientType);
        }
    }

    internal class Meta
    {
        private enum ClientTypes
        {
            Confidential,
            Public
        }

        internal static IEnumerable<string> ClientTypeList = new List<string>
        {
            ClientTypes.Public.ToString(),
            ClientTypes.Confidential.ToString(),
        };
    }
}