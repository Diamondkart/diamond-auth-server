namespace DiamondAuthServer.Domain.Constants
{
    public class ClaimConstants : CommonConstants
    {
        // convention : cx:{resource_name}:{key_name}
        public static readonly string CLAIM_EMAIL = FormProfileClaimKey("email");

        public static readonly string CLAIM_FIRSTNAME = FormProfileClaimKey("firstName");
        public static readonly string CLAIM_LASTNAME = FormProfileClaimKey("lastName");
        public static readonly string CLAIM_MIDDLENAME = FormProfileClaimKey("middleName");

        private static string FormProfileClaimKey(string claimName)
        {
            return $"{CLAIM_PREFIX}:{CLAIM_PROFILE}:{claimName}";
        }
    }
}