using Microsoft.EntityFrameworkCore;
using ApiProject.Data.Models;
using ApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Data.Repository
{
    public class ProductRepository : IRepository<ProductModel>
    {
        private DbSet<ProductModel> Collection;
        public ProductRepository(ApplicationContext context)
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
            return Collection.AsNoTracking();
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
