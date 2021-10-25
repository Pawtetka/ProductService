using ApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Business.Services.Interfaces
{
    interface IProductInStorageService
    {
        public IEnumerable<ProductInStorage> GetAll();
        public ProductInStorage GetById(int id);
        public void Update(ProductInStorage productInStorage);
        public void DeleteById(int id);
        public void Create(ProductInStorage productInStorage);
    }
}
