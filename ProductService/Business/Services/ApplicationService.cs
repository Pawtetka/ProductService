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
    public class ApplicationService : IApplicationService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public ApplicationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ICollection<DeliveryApplication> FindByName(string name)
        {
            var deliveryApplications = new List<DeliveryApplication>();
            foreach (var application in _unitOfWork.DeliveryApplicationRepository.GetAll())
            {
                if (application.Name.Equals(name))
                {
                    deliveryApplications.Add(_mapper.Map<DeliveryApplication>(application));
                }
            }
            return deliveryApplications;
        }

        public ICollection<DeliveryApplication> FindByDate(string date)
        {
            var deliveryApplications = new List<DeliveryApplication>();
            foreach (var application in _unitOfWork.DeliveryApplicationRepository.GetAll())
            {
                if (application.Date.Equals(date))
                {
                    deliveryApplications.Add(_mapper.Map<DeliveryApplication>(application));
                }
            }
            return deliveryApplications;
        }

        public ICollection<DeliveryApplication> FindByCount(string count)
        {
            var deliveryApplications = new List<DeliveryApplication>();
            foreach (var application in _unitOfWork.DeliveryApplicationRepository.GetAll())
            {
                if (application.ProductCount == Convert.ToInt32(count))
                {
                    deliveryApplications.Add(_mapper.Map<DeliveryApplication>(application));
                }
            }
            return deliveryApplications;
        }

    }
}
