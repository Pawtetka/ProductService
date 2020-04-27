using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Business.Services.Interfaces
{
    public interface IApplicationCreator
    {
        void Create(ApplicationParameters applicationParameters);
    }
}
