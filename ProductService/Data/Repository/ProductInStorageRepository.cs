using Microsoft.EntityFrameworkCore;
using ProductService.Data.Models;
using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Data.Repository
{
    public class ProductInStorageRepository : IRepository<ProductInStorageModel>
    {
        private DbSet<ProductInStorageModel> Collection;
        public ProductInStorageRepository(DbContext context)
        {
            Collection = context.Set<ProductInStorageModel>();
        }
        public void Add(ProductInStorageModel entity)
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

        public IEnumerable<ProductInStorageModel> GetAll()
        {
            return Collection;
        }

        public ProductInStorageModel GetById(int entityId)
        {
            return Collection.Find(entityId);
        }

        public void Update(ProductInStorageModel entity)
        {
            Collection.Update(entity);
        }
    }
}
