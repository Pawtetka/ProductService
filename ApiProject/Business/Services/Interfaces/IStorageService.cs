using ApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Business.Services.Interfaces
{
    public interface IStorageService
    {
        public IEnumerable<Storage> GetAll();
        public Storage GetById(int id);
        public void Update(Storage storage);
        public void DeleteById(int id);
        public void Create(Storage storage);
    }
}
