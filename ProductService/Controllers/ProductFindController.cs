using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers
{
    public class ProductFindController : Controller
    {
        public IActionResult ProductFindWindow()
        {
            return View();
        }
    }
}