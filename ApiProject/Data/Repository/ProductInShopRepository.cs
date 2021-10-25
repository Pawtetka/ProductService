using Microsoft.EntityFrameworkCore;
using ApiProject.Data.Models;
using ApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Data.Repository
{
    public class ProductInShopRepository : IRepository<ProductInShopModel>
    {
        private DbSet<ProductInShopModel> Collection;
        public ProductInShopRepository(ApplicationContext context)
        {
            Collection = context.Set<ProductInShopModel>();
        }
        public void Add(ProductInShopModel entity)
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

        public IEnumerable<ProductInShopModel> GetAll()
        {
            return Collection.AsNoTracking();
        }

        public ProductInShopModel GetById(int entityId)
        {
            return Collection.Find(entityId);
        }

        public void Update(ProductInShopModel entity)
        {
            Collection.Update(entity);
        }
    }
}
