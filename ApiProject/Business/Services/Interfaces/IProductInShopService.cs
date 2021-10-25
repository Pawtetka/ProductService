using ApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Business.Services.Interfaces
{
    interface IProductInShopService
    {
        public IEnumerable<ProductInShop> GetAll();
        public ProductInShop GetById(int id);
        public void Update(ProductInShop productInShop);
        public void DeleteById(int id);
        public void Create(ProductInShop productInShop);
    }
}
