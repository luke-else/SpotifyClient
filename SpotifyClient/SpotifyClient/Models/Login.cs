using System;

namespace SpotifyClient.Models
{
    public class Login
    {
        public string ClientID { get; } = "a25a9ec0fe5647f3a1ed8847b2048d77";

        public string ClientSecret { get; }= "8b0843a3e91d4eacb090f3f131e2db02";

        public string RedirectURI { get; }= "https://spotify.luke-else.com/App/authorise";
        
    }
}