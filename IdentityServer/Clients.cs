using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServer
{
    internal class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client> {
                new Client {
                    ClientId = "oauthClient",
                    ClientName = "Example Client Credentials Client Application",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret> {
                        new Secret("superSecretPassword".Sha256())},
                    AllowedScopes = new List<string> {"customAPI.read"}
                },
                new Client {
                    ClientId = "RestaurantSPA",
                    ClientName = "Restaurant Angular SPA Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = new List<string> { "openid", "profile", "api1" },
                    RedirectUris = new List<string> {"http://localhost:4200/auth/auth-callback"},
                    PostLogoutRedirectUris = new List<string> {"http://localhost:4200"},
                    AllowedCorsOrigins = new List<string> { "http://localhost:4200" },
                    AllowAccessTokensViaBrowser = true
                }
            };
        }
    }
}
