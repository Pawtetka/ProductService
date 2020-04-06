using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private ICollection<Product> Collection;
        public ProductRepository()
        {
            Collection = Data.Products;
        }
        public void Add(Product entity)
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

        public IEnumerable<Product> GetAll()
        {
            return Collection;
        }

        public Product GetById(int entityId)
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

        public void Update(Product entity)
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
