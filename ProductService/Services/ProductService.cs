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
        private UnitOfWork _unitOfWork;
        public ProductService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ICollection<Product> FindByName(string name)
        {
            var products = new List<Product>();
            foreach (var product in _unitOfWork.ProductRepository.GetAll())
            {
                if (product.Name.Equals(name))
                {
                    products.Add(product);
                }
            }
            return products;
        }

        public ICollection<Product> FindByApplicationNumber(string number)
        {
            var products = new List<Product>();
            foreach (var deliveryObject in _unitOfWork.DeliveryObjectRepository.GetAll())
            {
                if (deliveryObject.DeliveryApplication.Number == Convert.ToInt32(number))
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
