using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Business.Services.Interfaces
{
    public interface IApplicationService
    {
        ICollection<DeliveryApplication> FindByName(string name);
        ICollection<DeliveryApplication> FindByDate(string date);
        ICollection<DeliveryApplication> FindByCount(string count);

    }
}
