using Microsoft.EntityFrameworkCore;
using ProductService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<ShopModel> Shops { get; set; }
        public DbSet<StorageModel> Storages { get; set; }
        public DbSet<DeliveryApplicationModel> DeliveryApplications { get; set; }
        public DbSet<ProductInShopModel> ProductInShops { get; set; }
        public DbSet<ProductInStorageModel> ProductInStorages { get; set; }
        public DbSet<DeliveryObjectModel> DeliveryObjectModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region SeedData

            var product1 = new ProductModel
            {
                Id = 1,
                Name = "Product 1"
            };

            var product2 = new ProductModel
            {
                Id = 2,
                Name = "Product 2"
            };

            var shop1 = new ShopModel
            {
                Id = 1,
                Name = "Shop 1"
            };
            var storage1 = new StorageModel
            {
                Id = 1,
                Name = "Storage 1"
            };

            var productInShop1 = new ProductInShopModel
            {
                Id = 1,
                ProductId = 1,
                ShopId = 1
            };

            var productInShop2 = new ProductInShopModel
            {
                Id = 2,
                ProductId = 2,
                ShopId = 1
            };

            var productInStorage1 = new ProductInStorageModel
            {
                Id = 1,
                ProductId = 2,
                StorageId = 1
            };

            var deliveryApp1 = new DeliveryApplicationModel
            {
                Id = 1,
                Name = "Application 1",
                Number = 123,
                Date = "15.11.2000",
                ProductCount = 1,
                StorageId = 1
            };

            var deliveryApp2 = new DeliveryApplicationModel
            {
                Id = 2,
                Name = "Application 2",
                Number = 321,
                Date = "27.12.2000",
                ProductCount = 2,
                ShopId = 1
            };

            var deliveryObj1 = new DeliveryObjectModel
            {
                Id = 1,
                ProductId = 1,
                DeliveryApplicationId = 1
            };

            var deliveryObj2 = new DeliveryObjectModel
            {
                Id = 2,
                ProductId = 1,
                DeliveryApplicationId = 2
            };

            var deliveryObj3 = new DeliveryObjectModel
            {
                Id = 3,
                ProductId = 2,
                DeliveryApplicationId = 2
            };

            modelBuilder.Entity<ProductModel>().HasData(product1, product2);
            modelBuilder.Entity<ShopModel>().HasData(shop1);
            modelBuilder.Entity<StorageModel>().HasData(storage1);
            modelBuilder.Entity<ProductInShopModel>().HasData(productInShop1, productInShop2);
            modelBuilder.Entity<ProductInStorageModel>().HasData(productInStorage1);
            modelBuilder.Entity<DeliveryApplicationModel>().HasData(deliveryApp1, deliveryApp2);
            modelBuilder.Entity<DeliveryObjectModel>().HasData(deliveryObj1, deliveryObj2, deliveryObj3);

            #endregion
        }
    }
}
