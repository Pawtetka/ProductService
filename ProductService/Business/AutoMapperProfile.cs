using AutoMapper;
using ProductService.Models;
using ProductService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Business
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserRegisterData, User>();
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Shop, ShopModel>().ReverseMap();
            CreateMap<Storage, StorageModel>().ReverseMap();
            CreateMap<DeliveryApplication, DeliveryApplicationModel>().ReverseMap();
            CreateMap<ProductInShop, ProductInShopModel>().ReverseMap();
            CreateMap<ProductInStorage, ProductInStorageModel>().ReverseMap();
            CreateMap<DeliveryObject, DeliveryObjectModel>().ReverseMap();
        }
    }
}
