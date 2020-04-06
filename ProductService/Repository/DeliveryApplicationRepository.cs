using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Repository
{
    public class DeliveryApplicationRepository : IRepository<DeliveryApplication>
    {
        private ICollection<DeliveryApplication> Collection;
        public DeliveryApplicationRepository()
        {
            Collection = Data.DeliveryApplications;
        }
        public void Add(DeliveryApplication entity)
        {
            Collection.Add(entity);
        }

        public void DeleteById(int entityId)
        {
            foreach (var entity in Collection)
            {
                if (entity.Id == entityId)
                {
                    Collection.Remove(entity);
                    break;
                }
            }
        }

        public IEnumerable<DeliveryApplication> GetAll()
        {
            return Collection;
        }

        public DeliveryApplication GetById(int entityId)
        {
            foreach (var entity in Collection)
            {
                if (entity.Id == entityId)
                {
                    return entity;
                }
            }
            return null;
        }

        public void Update(DeliveryApplication entity)
        {
            foreach (var ent in Collection)
            {
                if (ent.Id == entity.Id)
                {
                    Collection.Remove(ent);
                    Collection.Add(entity);
                    break;
                }
            }
        }
    }
}
