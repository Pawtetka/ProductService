using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers
{
    public class MainController : Controller
    {
        public IActionResult MainWindow()
        {
            return View();
        }
    }
}