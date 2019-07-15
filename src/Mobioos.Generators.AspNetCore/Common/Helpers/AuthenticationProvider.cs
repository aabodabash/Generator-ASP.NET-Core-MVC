using System.Collections.Generic;

namespace Mobioos.Generators.AspNetCore
{
    public static class AuthenticationProviders
    {
        public static Dictionary<string, AuthenticationProviderPrompt> AuthenticationProviderPrompts { get; } = new Dictionary<string, AuthenticationProviderPrompt>
        {
            {"googleAuth", new AuthenticationProviderPrompt("GoogleAuthClientId","Google client id","GoogleAuthSecret","Google client secret") },
            {"microsoftAuth", new AuthenticationProviderPrompt("MicrosoftAuthClientId","Microsoft client id","MicrosoftAuthSecret","Microsoft client secret") },
            {"facebookAuth", new AuthenticationProviderPrompt("FacebookAuthConsumerKey","Facebook consumer key","FacebookAuthConsumerSecret","Facebook consumer secret") },
            {"twitterAuth", new AuthenticationProviderPrompt("TwitterAuthAppId","Twitter app id","TwitterAuthAppSecret","Twitter app secret") }
        };
    }

    public class AuthenticationProviderPrompt
    {
        public AuthenticationProviderPrompt(string clientName, string clientMessage, string secretName, string secretMessage)
        {
            ClientName = clientName;
            ClientMessage = clientMessage;
            SecretName = secretName;
            SecretMessage = secretMessage;
        }

        public string ClientName { get; set; }
        public string ClientMessage { get; set; }
        public string SecretName { get; set; }
        public string SecretMessage { get; set; }
    }
}
