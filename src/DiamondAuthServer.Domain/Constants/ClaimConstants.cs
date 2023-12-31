namespace DiamondAuthServer.Domain.Constants
{
    public class ClaimConstants
    {
        // convention : cx:{resource_name}:{key_name}
        public const string CLAIM_EMAIL = "cx:profile:email";
        public const string CLAIM_FIRSTNAME = "cx:profile:firstName";
        public const string CLAIM_LASTNAME = "cx:profile:lastName";
        public const string CLAIM_MIDDLENAME = "cx:profile:middleName";
    }
}