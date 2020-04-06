using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Repository
{
    public class ShopRepository : IRepository<Shop>
    {
        private ICollection<Shop> Collection;
        public ShopRepository()
        {
            Collection = Data.Shops;
        }
        public void Add(Shop entity)
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

        public IEnumerable<Shop> GetAll()
        {
            return Collection;
        }

        public Shop GetById(int entityId)
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

        public void Update(Shop entity)
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
