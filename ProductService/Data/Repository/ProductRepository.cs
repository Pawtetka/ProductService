using Microsoft.EntityFrameworkCore;
using ProductService.Data.Models;
using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Data.Repository
{
    public class ProductRepository : IRepository<ProductModel>
    {
        private DbSet<ProductModel> Collection;
        public ProductRepository(DbContext context)
        {
            Collection = context.Set<ProductModel>();
        }
        public void Add(ProductModel entity)
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

        public IEnumerable<ProductModel> GetAll()
        {
            return Collection;
        }

        public ProductModel GetById(int entityId)
        {
            return Collection.Find(entityId);
        }

        public void Update(ProductModel entity)
        {
            Collection.Update(entity);
        }
    }
}
