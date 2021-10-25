using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Data.Models
{
    public class ProductInStorageModel : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductModel Product { get; set; }
        public int StorageId { get; set; }
        public StorageModel Storage { get; set; }
    }
}
