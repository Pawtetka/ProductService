using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Models
{
    public static class Data
    {
        public static List<Product> Products = new List<Product>();
        public static List<Storage> Storages = new List<Storage>();
        public static List<Shop> Shops = new List<Shop>();
        public static List<DeliveryApplication> DeliveryApplications = new List<DeliveryApplication>();
        public static List<ProductInShop> ProductsInShops = new List<ProductInShop>();
        public static List<ProductInStorage> ProductsInStorages = new List<ProductInStorage>();
        public static List<DeliveryObject> DeliveryObjects = new List<DeliveryObject>();

        public static void LoadData()
        {
            Product product = new Product();
            Product product1 = new Product();
            Storage storage = new Storage();
            Shop shop = new Shop();
            DeliveryApplication deliveryApplication = new DeliveryApplication();
            DeliveryApplication deliveryApplication1 = new DeliveryApplication();
            ProductInStorage productInStorage = new ProductInStorage();
            ProductInShop productInShop = new ProductInShop();
            DeliveryObject deliveryObject = new DeliveryObject(); 
            DeliveryObject deliveryObject1 = new DeliveryObject();
            DeliveryObject deliveryObject2 = new DeliveryObject();


            product.Name = "Огурчик";
            product.Id = 1;
            Products.Add(product);

            product1.Name = "Помидор";
            product1.Id = 2;
            Products.Add(product1);

            storage.Id = 1;
            storage.Name = "Сильпо склад";
            Storages.Add(storage);

            productInStorage.Id = 1;
            productInStorage.Product = product;
            productInStorage.ProductId = product.Id;
            productInStorage.Storage = storage;
            productInStorage.StorageId = storage.Id;
            ProductsInStorages.Add(productInStorage);

            shop.Id = 1;
            shop.Name = "Сильпо";
            Shops.Add(shop);

            productInShop.Id = 1;
            productInShop.Product = product1;
            productInShop.ProductId = product1.Id;
            productInShop.Shop = shop;
            productInShop.ShopId = shop.Id;
            ProductsInShops.Add(productInShop);

            deliveryApplication.Id = 1;
            deliveryApplication.Name = "Заказ продуктов на склад Сильпо";
            deliveryApplication.Number = 123;
            deliveryApplication.ProductCount = 2;
            deliveryApplication.Storage = storage;
            deliveryApplication.StorageId = storage.Id;
            DeliveryApplications.Add(deliveryApplication);

            deliveryApplication1.Id = 2;
            deliveryApplication1.Name = "Заказ продуктов в магазин Сильпо";
            deliveryApplication1.Number = 456;
            deliveryApplication1.ProductCount = 1;
            deliveryApplication1.Shop = shop;
            deliveryApplication1.ShopId = shop.Id;
            DeliveryApplications.Add(deliveryApplication1);

            deliveryObject.Id = 1;
            deliveryObject.Product = product;
            deliveryObject.ProductId = product.Id;
            deliveryObject.DeliveryApplication = deliveryApplication;
            deliveryObject.DeliveryApplicationId = deliveryApplication.Id;
            DeliveryObjects.Add(deliveryObject);

            deliveryObject1.Id = 2;
            deliveryObject1.Product = product1;
            deliveryObject1.ProductId = product1.Id;
            deliveryObject1.DeliveryApplication = deliveryApplication;
            deliveryObject1.DeliveryApplicationId = deliveryApplication.Id;
            DeliveryObjects.Add(deliveryObject1);

            deliveryObject2.Id = 3;
            deliveryObject2.Product = product1;
            deliveryObject2.ProductId = product.Id;
            deliveryObject2.DeliveryApplication = deliveryApplication1;
            deliveryObject2.DeliveryApplicationId = deliveryApplication1.Id;
            DeliveryObjects.Add(deliveryObject2);
        }
    }
}
