using ApiProject.Models;
using ApiProject.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ApiProject.Business.Services.Interfaces;
using ApiProject.Data.Models;

namespace ApiProject.Business.Services
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

        public IEnumerable<Product> GetAll()
        {
            var products = _unitOfWork.ProductRepository.GetAll();
            var retProducts = _mapper.Map<IEnumerable<Product>>(products);
            return retProducts;
        }

        public Product GetById(int id)
        {
            var product = _unitOfWork.ProductRepository.GetById(id);
            var retProduct = _mapper.Map<Product>(product);
            return retProduct;
        }

        public void DeleteById(int id)
        {
            _unitOfWork.ProductRepository.DeleteById(id);
            _unitOfWork.Save();
        }

        public void Update(Product product)
        {
            var newProduct = _mapper.Map<ProductModel>(product);
            _unitOfWork.ProductRepository.Update(newProduct);
            _unitOfWork.Save();
        }

        public void Create(Product product)
        {
            var newProduct = _mapper.Map<ProductModel>(product);
            _unitOfWork.ProductRepository.Add(newProduct);
            _unitOfWork.Save();
        }
    }
}
