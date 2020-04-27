using ProductService.Models;
using ProductService.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProductService.Business.Services.Interfaces;

namespace ProductService.Business.Services
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ICollection<Product> FindByName(string name)
        {
            var products = new List<Product>();
            foreach (var product in _unitOfWork.ProductRepository.GetAll())
            {
                if (product.Name.Equals(name))
                {
                    products.Add(_mapper.Map<Product>(product));
                }
            }
            return products;
        }

        public ICollection<Product> FindByApplicationNumber(string number)
        {
            var products = new List<Product>();
            var deliveryApplications = _unitOfWork.DeliveryObjectRepository.GetAll().ToList();
            foreach (var deliveryObject in deliveryApplications)
            {
                if (_unitOfWork.DeliveryApplicationRepository.GetById(deliveryObject.DeliveryApplicationId).Number == Convert.ToInt32(number))
                {
                    products.Add(_mapper.Map<Product>(_unitOfWork.ProductRepository.GetById(deliveryObject.ProductId)));
                }
            }
            return products;
        }
        public ICollection<Product> FindByShop(string shopName)
        {
            var products = new List<Product>();
            foreach (var productInShop in _unitOfWork.ProductInShopRepository.GetAll().ToList())
            {
                if (_unitOfWork.ShopRepository.GetById(productInShop.ShopId).Name.Equals(shopName))
                {
                    products.Add(_mapper.Map<Product>(_unitOfWork.ProductRepository.GetById(productInShop.ProductId)));
                }
            }
            return products;
        }

        public ICollection<Product> FindByStorage(string storageName)
        {
            var products = new List<Product>();
            foreach (var productInStorage in _unitOfWork.ProductInStorageRepository.GetAll().ToList())
            {
                if (_unitOfWork.StorageRepository.GetById(productInStorage.StorageId).Name.Equals(storageName))
                {
                    products.Add(_mapper.Map<Product>(_unitOfWork.ProductRepository.GetById(productInStorage.ProductId)));
                }
            }
            return products;
        }
    }
}
