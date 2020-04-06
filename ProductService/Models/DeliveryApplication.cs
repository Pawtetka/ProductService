using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Models
{
    public class DeliveryApplication
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public Storage Storage { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}
