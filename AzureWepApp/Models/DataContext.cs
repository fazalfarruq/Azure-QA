using Microsoft.Azure.KeyVault;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyAddressBookPlus;
using System.IO;

namespace AddressWebApp.Models
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            var kv = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(KeyVaultService.GetToken));
            var sec = kv.GetSecretAsync(configuration["ConnectionStrings:ConnectionSecretUri"]).Result;
            KeyVaultService.DefaultConnection = sec.Value;
            
            optionsBuilder.UseSqlServer(KeyVaultService.DefaultConnection);

        }

        public DbSet<Address> Addresses { get; set; }

    }
}