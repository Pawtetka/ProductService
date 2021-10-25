using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Data.Models
{
    public class DeliveryApplicationModel : IEntity
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public int ProductCount { get; set; }
        public int? StorageId { get; set; }
        public StorageModel Storage { get; set; }
        public int? ShopId { get; set; }
        public ShopModel Shop { get; set; }
    }
}
