using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace wk2_AssetTracking_EF
{
    internal class MyDbContext : DbContext
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EFAssetTracking;Integrated Security=True";

        public DbSet<AssetType> AssetTypes { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Asset> Assets { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // We tell the app to use the connectionstring.
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            //Seeding Data for AssetTypes Table
            ModelBuilder.Entity<AssetType>().HasData(new AssetType { Id = 1, Type = "Phone" });
            ModelBuilder.Entity<AssetType>().HasData(new AssetType { Id = 2, Type = "Computer" });

            //Seeding Data for Offices Table
            ModelBuilder.Entity<Office>().HasData(new Office { Id = 1, Name = "Spain" });
            ModelBuilder.Entity<Office>().HasData(new Office { Id = 2, Name = "Sweden" });
            ModelBuilder.Entity<Office>().HasData(new Office { Id = 3, Name = "USA" });

            //Seeding Data for Assets Table
            ModelBuilder.Entity<Asset>().HasData(new Asset
            {
                Id = 1,
                Brand = "iPhone",
                Model = "8",
                PurchaseDate = new DateTime(2018, 12, 29),
                PriceInUSD = 1000.4,
                AssetTypeId = 1,
                OfficeId = 1
            });

            ModelBuilder.Entity<Asset>().HasData(new Asset
            {
                Id = 2,
                Brand = "HP",
                Model = "Elitebook",
                PurchaseDate = new DateTime(2019, 6, 1),
                PriceInUSD = 2000,
                AssetTypeId = 2,
                OfficeId = 1
            });

            ModelBuilder.Entity<Asset>().HasData(new Asset
            {
                Id = 3,
                Brand = "iPhone",
                Model = "11",
                PurchaseDate = new DateTime(2020, 9, 25),
                PriceInUSD = 30000,
                AssetTypeId = 1,
                OfficeId = 1
            });

            ModelBuilder.Entity<Asset>().HasData(new Asset
            {
                Id = 4,
                Brand = "Motorola",
                Model = "Razor",
                PurchaseDate = new DateTime(2020, 3, 16),
                PriceInUSD = 600.56,
                AssetTypeId = 1,
                OfficeId = 3
            });

        }
    }
}
