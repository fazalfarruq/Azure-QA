using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
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
            optionsBuilder.UseSqlServer(KeyVaultService.GetSecret().Result);
        }

        public DbSet<Address> Addresses { get; set; }

    }
}