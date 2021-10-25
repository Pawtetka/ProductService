using ApiProject.Business.Services.Interfaces;
using ApiProject.Data.Models;
using ApiProject.Data.Repository;
using ApiProject.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Business.Services
{
    public class StorageService : IStorageService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        public StorageService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Storage> GetAll()
        {
            var storage = _unitOfWork.StorageRepository.GetAll();
            var retShops = _mapper.Map<IEnumerable<Storage>>(storage);
            return retShops;
        }

        public Storage GetById(int id)
        {
            var storage = _unitOfWork.StorageRepository.GetById(id);
            var retShop = _mapper.Map<Storage>(storage);
            return retShop;
        }

        public void DeleteById(int id)
        {
            _unitOfWork.StorageRepository.DeleteById(id);
            _unitOfWork.Save();
        }

        public void Update(Storage storage)
        {
            var newStorage = _mapper.Map<StorageModel>(storage);
            _unitOfWork.StorageRepository.Update(newStorage);
            _unitOfWork.Save();
        }

        public void Create(Storage storage)
        {
            var newStorage = _mapper.Map<StorageModel>(storage);
            _unitOfWork.StorageRepository.Add(newStorage);
            _unitOfWork.Save();
        }
    }
}
