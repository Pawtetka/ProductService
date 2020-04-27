using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Data.Repository
{
    public interface IUnitOfWork
    {
        public DeliveryApplicationRepository DeliveryApplicationRepository { get; }
        public DeliveryObjectRepository DeliveryObjectRepository { get; }
        public ProductInShopRepository ProductInShopRepository { get; }
        public ProductInStorageRepository ProductInStorageRepository { get; }
        public ProductRepository ProductRepository { get; }
        public ShopRepository ShopRepository { get; }
        public StorageRepository StorageRepository { get; }
        void Save();
    }
}
