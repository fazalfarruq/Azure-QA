using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MyAddressBookPlus
{
    public static class KeyVaultService
    {
        public static string DefaultConnection { get; set; }

        public static async Task<string> GetToken(string authority, string resource, string scope)
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            var authContext = new AuthenticationContext(authority);
            ClientCredential clientCred = new ClientCredential(configuration["ConnectionStrings:ClientId"],
                        configuration["ConnectionStrings:ClientSecret"]);
            AuthenticationResult result = await authContext.AcquireTokenAsync(resource, clientCred);

            if (result == null)
                throw new InvalidOperationException("Failed to obtain the JWT token");

            return result.AccessToken;
        }
    }
}