using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Data.Models
{
    public class ShopModel : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
