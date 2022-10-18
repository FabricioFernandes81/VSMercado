namespace ClientServer.Utils
{
    public class TokenResponse
    {
        public string AccessToken { get; set; } = string.Empty;
        public DateTime AccessTokenExpiration { get; set; }

        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
