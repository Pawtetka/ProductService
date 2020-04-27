using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DeliveryApplicationRepository deliveryApplicationRepository;
        private DeliveryObjectRepository deliveryObjectRepository;
        private ProductInShopRepository productInShopRepository;
        private ProductInStorageRepository productInStorageRepository;
        private ProductRepository productRepository;
        private ShopRepository shopRepository;
        private StorageRepository storageRepository;
        private DbContext _context;
        public UnitOfWork(DbContext context)
        {
            _context = context;
        }
        public DeliveryApplicationRepository DeliveryApplicationRepository { get { return deliveryApplicationRepository ?? new DeliveryApplicationRepository(_context); } }
        public DeliveryObjectRepository DeliveryObjectRepository { get { return deliveryObjectRepository ?? new DeliveryObjectRepository(_context); } }
        public ProductInShopRepository ProductInShopRepository { get { return productInShopRepository ?? new ProductInShopRepository(_context); } }
        public ProductInStorageRepository ProductInStorageRepository { get { return productInStorageRepository ?? new ProductInStorageRepository(_context); } }
        public ProductRepository ProductRepository { get { return productRepository ?? new ProductRepository(_context); } }
        public ShopRepository ShopRepository { get { return shopRepository ?? new ShopRepository(_context); } }
        public StorageRepository StorageRepository { get { return storageRepository ?? new StorageRepository(_context); } }
    }
}
