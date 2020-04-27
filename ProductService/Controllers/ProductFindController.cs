using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductService.Models;

namespace ProductService.Controllers
{
    public class ProductFindController : Controller
    {
        private Business.Services.ProductService _productService;
        public ProductFindController(Business.Services.ProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult ProductFindWindow()
        {
            return View("ProductFindWindow", new List<Product>()); 
        }
        [HttpPost]
        public IActionResult ProductFindWindow(string findType, string findText)
        {            
            return View("ProductFindWindow", GetProducts(findType, findText));
        }

        private ICollection<Product> GetProducts(string findType, string findText)
        {
            //I have no choise...
            switch (findType)
            {
                case "Name":
                    return _productService.FindByName(findText);
                case "AppNumber":
                    return _productService.FindByApplicationNumber(findText);
                case "Storage":
                    return _productService.FindByStorage(findText);
                case "Shop":
                    return _productService.FindByShop(findText);
                default:
                    break;
            }
            return null;
        }
    }
}