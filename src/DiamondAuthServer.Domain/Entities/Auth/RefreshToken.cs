namespace DiamondAuthServer.Domain.Entities.Auth
{
    public class RefreshToken
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int AbsoluteRefreshTokenLifetime { get; set; }
        public int SlidingRefreshTokenLifetime { get; set; }
        public string RefreshTokenUsage { get; set; }
        public string RefreshTokenExpiration { get; set; }
        public bool UpdateAccessTokenClaimsOnRefresh { get; set; }

        public bool IsRefreshTokenUsageValid()
        {
            return Meta.RefreshTokenUsageList.Contains(RefreshTokenUsage);
        }

        public bool IsRefreshTokenExpiration()
        {
            return Meta.RefreshTokenExpirationList.Contains(RefreshTokenExpiration);
        }
    }

    internal class Meta
    {
        private enum RefreshTokenUsages
        {
            ReUse,
            OneTime
        }

        private enum RefreshTokenExpiration
        {
            Absolute,
            Sliding
        }

        internal static IEnumerable<string> RefreshTokenUsageList = new List<string>
        {
            RefreshTokenUsages.OneTime.ToString(),
            RefreshTokenUsages.ReUse.ToString(),
        };

        internal static IEnumerable<string> RefreshTokenExpirationList = new List<string>
        {
            RefreshTokenExpiration.Absolute.ToString(),
            RefreshTokenExpiration.Sliding.ToString(),
        };
    }
}