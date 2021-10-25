using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Data.Models
{
    public class ProductInShopModel : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductModel Product { get; set; }
        public int ShopId { get; set; }
        public ShopModel Shop { get; set; }
    }
}
