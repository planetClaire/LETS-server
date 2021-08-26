using System.Collections.Generic;
using IdentityServer4.Models;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                // an example webapi
                 new ApiScope("api1", "My API"),
                 // our graphql api
                 new ApiScope("letsgql", "LETS GraphQL")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                // an example client
                new Client
                {
                    ClientId = "client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "api1", "letsgql" }
                },
            };

    }
}
