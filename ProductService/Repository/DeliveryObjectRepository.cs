using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Repository
{
    public class DeliveryObjectRepository : IRepository<DeliveryObject>
    {
        private ICollection<DeliveryObject> Collection;
        public DeliveryObjectRepository()
        {
            Collection = Data.DeliveryObjects;
        }
        public void Add(DeliveryObject entity)
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

        public IEnumerable<DeliveryObject> GetAll()
        {
            return Collection;
        }

        public DeliveryObject GetById(int entityId)
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

        public void Update(DeliveryObject entity)
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
