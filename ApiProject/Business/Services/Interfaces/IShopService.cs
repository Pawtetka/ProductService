using ApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Business.Services.Interfaces
{
    public interface IShopService
    {
        public IEnumerable<Shop> GetAll();
        public Shop GetById(int id);
        public void Update(Shop shop);
        public void DeleteById(int id);
        public void Create(Shop shop);
    }
}
