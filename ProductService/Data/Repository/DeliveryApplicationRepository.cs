﻿using Microsoft.EntityFrameworkCore;
using ProductService.Data.Models;
using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Data.Repository
{
    public class DeliveryApplicationRepository : IRepository<DeliveryApplicationModel>
    {
        private DbSet<DeliveryApplicationModel> _dbSet;
        public DeliveryApplicationRepository(ApplicationContext context)
        {
            _dbSet = context.Set<DeliveryApplicationModel>();
        }
        public void Add(DeliveryApplicationModel entity)
        {
            _dbSet.Add(entity);
        }

        public void DeleteById(int entityId)
        {
            foreach (var entity in _dbSet)
            {
                if (entity.Id == entityId)
                {
                    _dbSet.Remove(entity);
                    break;
                }
            }
        }

        public IEnumerable<DeliveryApplicationModel> GetAll()
        {
            return _dbSet;
        }

        public DeliveryApplicationModel GetById(int entityId)
        {
            return _dbSet.Find(entityId);
        }

        public void Update(DeliveryApplicationModel entity)
        {
            _dbSet.Update(entity);
        }
    }
}
