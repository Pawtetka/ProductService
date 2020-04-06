using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Repository
{
    interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        T GetById(int entityId);
        void DeleteById(int entityId);
        IEnumerable<T> GetAll();
    }
}
