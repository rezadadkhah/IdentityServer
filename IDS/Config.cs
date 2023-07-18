using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace IDS
{
    public static class Config
    {

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource
                {
                    Name = "api1",
                    DisplayName = "API #1",
                    Description = "Allow the application to access API #1 on your behalf",
                    Scopes = new List<string> {"api1.read", "api1.write"},
                    ApiSecrets = new List<Secret> {new Secret("secret".Sha256())}, // change me!
                    UserClaims = new List<string> {"role"}
                },
                new ApiResource
                {
                    Name = "api2",
                    DisplayName = "API #2",
                    Description = "Allow the application to access API #2 on your behalf",
                    Scopes = new List<string> {"api2.read", "api2.write"},
                    ApiSecrets = new List<Secret> {new Secret("secret".Sha256())}, // change me!
                    UserClaims = new List<string> {"role"}
                }
            };
        }
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "CCClient",
                    ClientName = "Example client application using client credentials",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret> {new Secret("secret".Sha256())}, // change me!
                    AllowedScopes = new List<string> {"api1.read", "api2.read" }
                },
                //new Client
                //{
                //    ClientId = "oidcClient",
                //    ClientName = "Example Client Application",
                //    ClientSecrets = new List<Secret> {new Secret("secret".Sha256())}, // change me!
    
                //    AllowedGrantTypes = GrantTypes.Code,
                //    RedirectUris = new List<string> {"https://localhost:5002/signin-oidc"},
                //    AllowedScopes = new List<string>
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //        IdentityServerConstants.StandardScopes.Email,
                //        "role",
                //        "api1.read"
                //    },

                //    RequirePkce = true,
                //    AllowPlainTextPkce = false
                //},
                new Client
                {
                    ClientId = "ROPClient",
                    ClientName = "Example client application using Resource Owner Password",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = new List<Secret> {new Secret("secret".Sha256())},
                    AllowedScopes = new List<string> { "api1.read","api2.read", IdentityServerConstants.StandardScopes.OpenId }
                }
            };

        }
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string> {"role"}
                }
            };
        }
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new[]
            {
                new ApiScope("api1.read", "Read Access to API #1"),
                new ApiScope("api1.write", "Write Access to API #1"),
                new ApiScope("api2.read", "Read Access to API #2"),
                new ApiScope("api2.write", "Write Access to API #2")
            };
        }
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser> {
                new TestUser {
                    SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    Username = "username",
                    Password = "password",
                    Claims = new List<Claim> {
                        new Claim(JwtClaimTypes.Email, "scott@scottbrady91.com"),
                        new Claim(JwtClaimTypes.Role, "admin")
                    }
                }
            };
        }
    }
}
