using ApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Business.Services.Interfaces
{
    interface IDeliveryApplicationService
    {
        public IEnumerable<DeliveryApplication> GetAll();
        public DeliveryApplication GetById(int id);
        public void Update(DeliveryApplication deliveryApplication);
        public void DeleteById(int id);
        public void Create(DeliveryApplication deliveryApplication);
    }
}
