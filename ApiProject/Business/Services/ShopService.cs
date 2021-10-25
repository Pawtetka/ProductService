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
    public class ShopService : IShopService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        public ShopService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Shop> GetAll()
        {
            var shops = _unitOfWork.ShopRepository.GetAll();
            var retShops = _mapper.Map<IEnumerable<Shop>>(shops);
            return retShops;
        }

        public Shop GetById(int id)
        {
            var shop = _unitOfWork.ShopRepository.GetById(id);
            var retShop = _mapper.Map<Shop>(shop);
            return retShop;
        }

        public void DeleteById(int id)
        {
            _unitOfWork.ShopRepository.DeleteById(id);
            _unitOfWork.Save();
        }

        public void Update(Shop shop)
        {
            var newShop = _mapper.Map<ShopModel>(shop);
            _unitOfWork.ShopRepository.Update(newShop);
            _unitOfWork.Save();
        }

        public void Create(Shop shop)
        {
            var newShop = _mapper.Map<ShopModel>(shop);
            _unitOfWork.ShopRepository.Add(newShop);
            _unitOfWork.Save();
        }
    }
}
