using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Models
{
    public class DeliveryObject
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int DeliveryApplicationId { get; set; }
        public DeliveryApplication DeliveryApplication { get; set; }    
    }
}
