using ProductService.Models;
using ProductService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Services
{
    public class ApplicationCreator
    {
        private DeliveryApplication deliveryApplication;
        private DeliveryObject deliveryObject;
        /*private DeliveryApplicationRepository _deliveryApplicationRepository;
        private DeliveryObjectRepository _deliveryObjectRepository;
        private ShopRepository _shopRepository;
        private StorageRepository _storageRepository;*/
        private ProductService _productService;
        private UnitOfWork _unitOfWork;
        public ApplicationCreator(/*DeliveryApplicationRepository deliveryApplicationRepository, DeliveryObjectRepository deliveryObjectRepository,
                                  ShopRepository shopRepository, StorageRepository storageRepository,*/ ProductService productService, UnitOfWork unitOfWork)
        {
            /*_deliveryApplicationRepository = deliveryApplicationRepository;
            _deliveryObjectRepository = deliveryObjectRepository;
            _shopRepository = shopRepository;
            _storageRepository = storageRepository;*/
            _productService = productService;
            _unitOfWork = unitOfWork;
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
                    deliveryApplication.Shop = shop;
                }
            }
            foreach (var storage in _unitOfWork.StorageRepository.GetAll())
            {
                if (storage.Name.Equals(applicationParameters.StorageName))
                {
                    deliveryApplication.StorageId = storage.Id;
                    deliveryApplication.Storage = storage;
                }
            }
            _unitOfWork.DeliveryApplicationRepository.Add(deliveryApplication);
        }
        private void CreateDelObj(ApplicationParameters applicationParameters)
        {
            foreach (var product in applicationParameters.ProductNames)
            {
                deliveryObject = new DeliveryObject();
                deliveryObject.Id = applicationParameters.DeliveryObjectId;
                deliveryObject.ProductId = _productService.FindByName(product).Id;
                deliveryObject.DeliveryApplicationId = applicationParameters.DeliveryApplicationId;
                deliveryObject.Product = _productService.FindByName(product);
                deliveryObject.DeliveryApplication = deliveryApplication;
                _unitOfWork.DeliveryObjectRepository.Add(deliveryObject);
            }
        }
    }
}
