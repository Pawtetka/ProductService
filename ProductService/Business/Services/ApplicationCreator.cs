using ProductService.Models;
using ProductService.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProductService.Data.Models;
using ProductService.Business.Services.Interfaces;

namespace ProductService.Business.Services
{
    public class ApplicationCreator : IApplicationCreator
    {
        private DeliveryApplication deliveryApplication;
        private DeliveryObject deliveryObject;
        private IProductService _productService;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public ApplicationCreator(IProductService productService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productService = productService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Create(ApplicationParameters applicationParameters)
        {
            CreateDelApp(applicationParameters);
            CreateDelObj(applicationParameters);        }
        
        private void CreateDelApp(ApplicationParameters applicationParameters)
        {
            deliveryApplication = new DeliveryApplication();
            deliveryApplication.Id = applicationParameters.DeliveryApplicationId;
            deliveryApplication.Number = applicationParameters.Number;
            deliveryApplication.Name = applicationParameters.Name;
            deliveryApplication.Date = applicationParameters.Date;
            deliveryApplication.ProductCount = applicationParameters.ProductCount;
            foreach (var shop in _unitOfWork.ShopRepository.GetAll())
            {
                if (shop.Name.Equals(applicationParameters.ShopName))
                {
                    deliveryApplication.ShopId = shop.Id;
                    //deliveryApplication.Shop = _mapper.Map<Shop>(shop);
                }
            }
            foreach (var storage in _unitOfWork.StorageRepository.GetAll())
            {
                if (storage.Name.Equals(applicationParameters.StorageName))
                {
                    deliveryApplication.StorageId = storage.Id;
                    //deliveryApplication.Storage = _mapper.Map<Storage>(storage);
                }
            }
            _unitOfWork.DeliveryApplicationRepository.Add(_mapper.Map<DeliveryApplicationModel>(deliveryApplication));
        }
        private void CreateDelObj(ApplicationParameters applicationParameters)
        {
            foreach (var product in applicationParameters.ProductNames)
            {
                deliveryObject = new DeliveryObject();
                deliveryObject.Id = applicationParameters.DeliveryObjectId;
                deliveryObject.ProductId = _productService.FindByName(product).First().Id;
                deliveryObject.DeliveryApplicationId = applicationParameters.DeliveryApplicationId;
                //deliveryObject.Product = _productService.FindByName(product).First();
                //deliveryObject.DeliveryApplication = deliveryApplication;
                _unitOfWork.DeliveryObjectRepository.Add(_mapper.Map<DeliveryObjectModel>(deliveryObject));
            }
        }
    }
}
