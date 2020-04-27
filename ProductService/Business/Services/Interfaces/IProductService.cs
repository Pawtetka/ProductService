using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Business.Services.Interfaces
{
    public interface IProductService
    {
        ICollection<Product> FindByName(string name);
        ICollection<Product> FindByApplicationNumber(string number);
        ICollection<Product> FindByShop(string shopName);
        ICollection<Product> FindByStorage(string storageName);
    }
}
