using AutoMapper;
using ApiProject.Models;
using ApiProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Business
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
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
