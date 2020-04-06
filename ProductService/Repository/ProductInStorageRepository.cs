using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Repository
{
    public class ProductInStorageRepository : IRepository<ProductInStorage>
    {
        private ICollection<ProductInStorage> Collection;
        public ProductInStorageRepository()
        {
            Collection = Data.ProductsInStorages;
        }
        public void Add(ProductInStorage entity)
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

        public IEnumerable<ProductInStorage> GetAll()
        {
            return Collection;
        }

        public ProductInStorage GetById(int entityId)
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

        public void Update(ProductInStorage entity)
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
