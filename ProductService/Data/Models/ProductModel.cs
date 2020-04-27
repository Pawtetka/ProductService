using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Data.Models
{
    public class ProductModel : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
