using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Repository
{
    public class UnitOfWork
    {
        private DeliveryApplicationRepository deliveryApplicationRepository;
        private DeliveryObjectRepository deliveryObjectRepository;
        private ProductInShopRepository productInShopRepository;
        private ProductInStorageRepository productInStorageRepository;
        private ProductRepository productRepository;
        private ShopRepository shopRepository;
        private StorageRepository storageRepository;
        public DeliveryApplicationRepository DeliveryApplicationRepository { get { return deliveryApplicationRepository ?? new DeliveryApplicationRepository(); } }
        public DeliveryObjectRepository DeliveryObjectRepository { get { return deliveryObjectRepository ?? new DeliveryObjectRepository(); } }
        public ProductInShopRepository ProductInShopRepository { get { return productInShopRepository ?? new ProductInShopRepository(); } }
        public ProductInStorageRepository ProductInStorageRepository { get { return productInStorageRepository ?? new ProductInStorageRepository(); } }
        public ProductRepository ProductRepository { get { return productRepository ?? new ProductRepository(); } }
        public ShopRepository ShopRepository { get { return shopRepository ?? new ShopRepository(); } }
        public StorageRepository StorageRepository { get { return storageRepository ?? new StorageRepository(); } }
    }
}
