using ApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Business.Services.Interfaces
{
    public interface IProductService
    {
        public IEnumerable<Product> GetAll();
        public Product GetById(int id);
        public void Update(Product product);
        public void DeleteById(int id);
        public void Create(Product product);
    }
}
