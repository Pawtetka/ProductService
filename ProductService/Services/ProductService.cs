using ProductService.Models;
using ProductService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Services
{
    public class ProductService
    {
        /*private ProductRepository _productRepository;
        private DeliveryObjectRepository _deliveryObjectRepository;
        private ProductInShopRepository _productInShopRepository;
        private ProductInStorageRepository _productInStorageRepository;*/
        private UnitOfWork _unitOfWork;
        public ProductService(/*ProductRepository productRepository, DeliveryObjectRepository deliveryObjectRepository,
                              ProductInShopRepository productInShopRepository, ProductInStorageRepository productInStorageRepository*/ UnitOfWork unitOfWork)
        {
            /*_productRepository = productRepository;
            _deliveryObjectRepository = deliveryObjectRepository;
            _productInShopRepository = productInShopRepository;
            _productInStorageRepository = productInStorageRepository;*/
            _unitOfWork = unitOfWork;
        }

        public Product FindByName(string name)
        {
            var products = new Product();
            foreach (var product in _unitOfWork.ProductRepository.GetAll())
            {
                if (product.Name.Equals(name))
                {
                    products = product;
                }
            }
            return products;
        }

        public ICollection<Product> FindByApplicationNumber(int number)
        {
            var products = new List<Product>();
            foreach (var deliveryObject in _unitOfWork.DeliveryObjectRepository.GetAll())
            {
                if (deliveryObject.DeliveryApplication.Number == number)
                {
                    products.Add(deliveryObject.Product);
                }
            }
            return products;
        }
        public ICollection<Product> FindByShop(string shopName)
        {
            var products = new List<Product>();
            foreach (var productInShop in _unitOfWork.ProductInShopRepository.GetAll())
            {
                if (productInShop.Shop.Name.Equals(shopName))
                {
                    products.Add(productInShop.Product);
                }
            }
            return products;
        }

        public ICollection<Product> FindByStorage(string storageName)
        {
            var products = new List<Product>();
            foreach (var productInStorage in _unitOfWork.ProductInStorageRepository.GetAll())
            {
                if (productInStorage.Storage.Name.Equals(storageName))
                {
                    products.Add(productInStorage.Product);
                }
            }
            return products;
        }
    }
}
