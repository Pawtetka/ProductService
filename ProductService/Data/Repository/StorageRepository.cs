using Microsoft.EntityFrameworkCore;
using ProductService.Data.Models;
using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Data.Repository
{
    public class StorageRepository : IRepository<StorageModel>
    {
        private DbSet<StorageModel> Collection;
        public StorageRepository(DbContext context)
        {
            Collection = context.Set<StorageModel>(); ;
        }
        public void Add(StorageModel entity)
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

        public IEnumerable<StorageModel> GetAll()
        {
            return Collection;
        }

        public StorageModel GetById(int entityId)
        {
            return Collection.Find(entityId);
        }

        public void Update(StorageModel entity)
        {
            Collection.Update(entity);
        }
    }
}
