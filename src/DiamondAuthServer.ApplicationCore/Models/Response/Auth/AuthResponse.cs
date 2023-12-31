using System.Text.Json.Serialization;

namespace DiamondAuthServer.ApplicationCore.Models.Response.Auth
{
    public class AuthResponse
    {
        [JsonPropertyName("id_token")]
        public string IdToken { get; set; }

        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonPropertyName("error")]
        public string Error { get; set; }
    }
}