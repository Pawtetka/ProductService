using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Models
{
    public class DeliveryApplication
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public int ProductCount { get; set; }

        public int? StorageId { get; set; }
        public Storage Storage { get; set; }
        public int? ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}
