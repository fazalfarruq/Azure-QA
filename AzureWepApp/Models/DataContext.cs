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
            optionsBuilder.UseSqlServer(KeyVaultService.DefaultConnection);

        }

        public DbSet<Address> Addresses { get; set; }

    }
}