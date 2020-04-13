﻿using ProductService.Models;
using ProductService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Services
{
    public class ApplicationService
    {
        private UnitOfWork _unitOfWork;
        public ApplicationService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ICollection<DeliveryApplication> FindByName(string name)
        {
            var deliveryApplications = new List<DeliveryApplication>();
            foreach (var application in _unitOfWork.DeliveryApplicationRepository.GetAll())
            {
                if (application.Name.Equals(name))
                {
                    deliveryApplications.Add(application);
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
                    deliveryApplications.Add(application);
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
                    deliveryApplications.Add(application);
                }
            }
            return deliveryApplications;
        }

    }
}
