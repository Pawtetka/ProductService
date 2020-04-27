using Microsoft.EntityFrameworkCore;
using ProductService.Data.Models;
using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Data.Repository
{
    public class ShopRepository : IRepository<ShopModel>
    {
        private DbSet<ShopModel> Collection;
        public ShopRepository(ApplicationContext context)
        {
            Collection = context.Set<ShopModel>();
        }
        public void Add(ShopModel entity)
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

        public IEnumerable<ShopModel> GetAll()
        {
            return Collection;
        }

        public ShopModel GetById(int entityId)
        {
            return Collection.Find(entityId);
        }

        public void Update(ShopModel entity)
        {
            Collection.Update(entity);
        }
    }
}
