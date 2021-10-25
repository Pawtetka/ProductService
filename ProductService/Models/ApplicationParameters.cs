using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Models
{
    public class ApplicationParameters
    {
        public int DeliveryObjectId { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public int ProductCount { get; set; }
        public string CustomerName { get; set; }
        public List<string> ProductNames { get; set; } = new List<string>();
    }
}
