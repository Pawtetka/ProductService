﻿using Microsoft.EntityFrameworkCore;
using ApiProject.Data.Models;
using ApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Data.Repository
{
    public class DeliveryObjectRepository : IRepository<DeliveryObjectModel>
    {
        private DbSet<DeliveryObjectModel> Collection;
        public DeliveryObjectRepository(ApplicationContext context)
        {
            Collection = context.Set<DeliveryObjectModel>();
        }
        public void Add(DeliveryObjectModel entity)
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

        public IEnumerable<DeliveryObjectModel> GetAll()
        {
            return Collection.AsNoTracking();
        }

        public DeliveryObjectModel GetById(int entityId)
        {
            return Collection.Find(entityId);
        }

        public void Update(DeliveryObjectModel entity)
        {
            Collection.Update(entity);
        }
    }
}
