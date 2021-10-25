using ApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Business.Services.Interfaces
{
    interface IDeliveryObjectService
    {
        public IEnumerable<DeliveryObject> GetAll();
        public DeliveryObject GetById(int id);
        public void Update(DeliveryObject deliveryObject);
        public void DeleteById(int id);
        public void Create(DeliveryObject deliveryObject);
    }
}
