using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductService.Models;

namespace ProductService.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        public IActionResult MainWindow()
        {
            return View();
        }
    }
}